using SocialMedia.Models.ResponseModel;

namespace SocialMedia.Controllers
{
    public class GetSuggestionRequestModel
    {
        public long id { get; set; }
        public long maxDegreeOfConnection { get; set; }
        public long numberOfSugestion { get; set; }
    }
}