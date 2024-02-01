using SocialMedia.Models.BusinessModels;

namespace SocialMedia.Models.RequestModel;

public class AddUserRequestModel
{
    public UserDto[] Users { get; set; }
}