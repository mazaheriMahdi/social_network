using SocialMedia.Models.ResponseModel;

namespace SocialMedia.Abstraction;

public interface IUserGraphService
{
    void GenerateGraph();
    ConnectionSuggestionResponseModel GetConnectionSuggestion(long id, long maxDegreeOfConnection, long numberOfSugestion);
}