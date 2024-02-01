using System.Collections.Concurrent;
using SocialMedia.Abstraction;
using SocialMedia.Exceptions;
using SocialMedia.Graph;
using SocialMedia.Models.BusinessModels;

namespace SocialMedia.Service;

public class UserGraphService : IUserGraphService
{
    private IStorageService _storageService;
    private IScoringAlgorithm _scoringAlgorithm;

    public UserGraphService(IStorageService storageService, IScoringAlgorithm scoringAlgorithm)
    {
        _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
        _scoringAlgorithm = scoringAlgorithm ?? throw new ArgumentNullException(nameof(scoringAlgorithm));
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

                var score = _scoringAlgorithm.Score(vertex.getElement(), targetVertex.getElement());
                graph.insertEdge(vertex, targetVertex, score);
            });
        }

        _storageService.SaveGraph(graph);
    }
}