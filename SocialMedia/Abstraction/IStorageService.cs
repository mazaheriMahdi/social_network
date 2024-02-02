using SocialMedia.Graph;
using SocialMedia.Models.BusinessModels;
using SocialMedia.Models.RequestModel;

namespace SocialMedia.Abstraction;

public interface IStorageService
{
    void AddToStorage(AddUserRequestModel addUserRequestModel);
    void SaveGraph(IGraph<int, User> graph);
    User[] GetAllUsers();
    IGraph<int, User> GetGraph();
}