using SocialMedia.Models.RequestModel;

namespace SocialMedia.Models.ResponseModel;

public class ConnectionSuggestionResponseModel
{
    public UserDto[] SuggesttedConnections { get; set; }
    public long TakenTime { get; set; }
}