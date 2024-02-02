using System.Collections.Concurrent;
using System.Diagnostics;
using AutoMapper;
using SocialMedia.Abstraction;
using SocialMedia.Exceptions;
using SocialMedia.Graph;
using SocialMedia.Models.BusinessModels;
using SocialMedia.Models.RequestModel;
using SocialMedia.Models.ResponseModel;

namespace SocialMedia.Service;

public class UserGraphService : IUserGraphService
{
    private readonly IStorageService _storageService;
    private readonly IScoringAlgorithm _scoringAlgorithm;
    private readonly IFindingVerticesWithDistance<int, User> _findingVerticesWithDistance;
    private readonly IMapper mapper;
    public UserGraphService(IStorageService storageService, IScoringAlgorithm scoringAlgorithm, IFindingVerticesWithDistance<int, User> findingVerticesWithDistance, IMapper mapper)
    {
        _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
        _scoringAlgorithm = scoringAlgorithm ?? throw new ArgumentNullException(nameof(scoringAlgorithm));
        _findingVerticesWithDistance = findingVerticesWithDistance ?? throw new ArgumentNullException(nameof(findingVerticesWithDistance));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public void GenerateGraph()
    {
        var userList = _storageService.GetAllUsers();

        var graph = new AdjacencyMapGraph<int, User>(false);

        var idToVertexMap = new ConcurrentDictionary<long, Vertex<int, User>>();

        foreach (var user in userList)
        {
            idToVertexMap[user.Id] = graph.insertVertex(user);
        }

        foreach (var vertex in graph.vertices())
        {
            var connectionIds = vertex.getElement().ConnectionId.ToList();
            connectionIds.ForEach(id =>
            {
                var isTargetVertexExist = idToVertexMap.TryGetValue(id, out var targetVertex);
                if (!isTargetVertexExist)
                {
                    throw new ThereIsNoVertexWithGivenIdFoundInGraph();
                }

                var score = _scoringAlgorithm.Score(vertex.getElement(), targetVertex.getElement(), 1);
                graph.insertEdge(vertex, targetVertex, score);
            });
        }

        _storageService.SaveGraph(graph);
    }

    public ConnectionSuggestionResponseModel GetConnectionSuggestion(long id, long maxDegreeOfConnection, long numberOfSugestion)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        var priorityQueue = new PriorityQueue<Vertex<int, User>, int>();

        var graph = _storageService.GetGraph();

        if (graph is null) throw new TheseIsNoSavedGraphForSuggestion();

        var targetVertex = graph.vertices().Single(item => item.getElement().Id.Equals(id));

        for (int degree = 2; degree < maxDegreeOfConnection; degree++)
        {
            var listOfOneLevelVertex = _findingVerticesWithDistance.FindVertices(graph, targetVertex, degree);

            listOfOneLevelVertex.ForEach(vertex =>
            {
                var score = _scoringAlgorithm.Score(vertex.getElement(), targetVertex.getElement(), degree);
                priorityQueue.Enqueue(vertex, score);
            });
        }

        var result = new List<User>();
        for (int i = 0; i < numberOfSugestion; i++)
        {
            if (priorityQueue.TryDequeue(out var vertex, out var _))
            {
                result.Add(vertex.getElement());
            }
            else
            {
                break;
            }
        }
        stopWatch.Stop();
        return new ConnectionSuggestionResponseModel
        {
            SuggesttedConnections = mapper.Map<User[], UserDto[]>(result.ToArray()),
            TakenTime = stopWatch.Elapsed
        };

    }
}