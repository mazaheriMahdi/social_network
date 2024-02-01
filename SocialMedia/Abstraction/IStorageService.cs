using SocialMedia.Models.BusinessModels;
using SocialMedia.Models.RequestModel;

namespace SocialMedia.Abstraction;

public interface IStorageService
{
    void AddToStorage(AddUserRequestModel addUserRequestModel);
    User[] GetAllUsers();
}