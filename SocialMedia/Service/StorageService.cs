using AutoMapper;
using SocialMedia.Abstraction;
using SocialMedia.Models.BusinessModels;
using SocialMedia.Models.RequestModel;

namespace SocialMedia.Service;

public class StorageService : IStorageService
{
    private readonly IMapper _mapper;
    private readonly List<User> _users;

    public StorageService(IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _users = new List<User>();
    }

    public void AddToStorage(AddUserRequestModel addUserRequestModel)
    {
        _users.AddRange(_mapper.Map<UserDto[], User[]>(addUserRequestModel.Users));
    }

    public User[] GetAllUsers()
    {
        return _users.ToArray();
    }
}