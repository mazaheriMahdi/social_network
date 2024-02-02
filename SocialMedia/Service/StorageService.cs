using AutoMapper;
using SocialMedia.Abstraction;
using SocialMedia.Graph;
using SocialMedia.Models.BusinessModels;
using SocialMedia.Models.RequestModel;

namespace SocialMedia.Service;

public class StorageService : IStorageService
{
    private readonly IMapper _mapper;
    private readonly List<User> _users;
    private IGraph<int, User> _graph;

    public StorageService(IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _users = new List<User>();
    }

    public void AddToStorage(AddUserRequestModel addUserRequestModel)
    {
        _users.AddRange(_mapper.Map<UserDto[], User[]>(addUserRequestModel.Users));
    }

    public void SaveGraph(IGraph<int, User> graph)
    {
        _graph = graph;
    }

    public IGraph<int, User> GetGraph()
    {
        return _graph;
    }


    public User[] GetAllUsers()
    {
        return _users.ToArray();
    }
}