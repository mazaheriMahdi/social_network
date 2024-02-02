using Microsoft.AspNetCore.Mvc;
using SocialMedia.Abstraction;
using SocialMedia.Models.BusinessModels;
using SocialMedia.Models.RequestModel;
using SocialMedia.Models.ResponseModel;

namespace SocialMedia.Controllers;

[ApiController]
[Route("Network")]
public class NetworkController : ControllerBase
{
    private readonly IStorageService _storageService;
    private readonly IUserGraphService _userGraphService;

    public NetworkController(IStorageService storageService, IUserGraphService userGraphService)
    {
        _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
        _userGraphService = userGraphService ?? throw new ArgumentNullException(nameof(userGraphService));
    }

    [HttpPost]
    public IActionResult AddUsers([FromBody] AddUserRequestModel addUserRequestModel)
    {
        _storageService.AddToStorage(addUserRequestModel);
        return Ok("User has been added to dataBase");
    }

    [HttpGet]
    public ActionResult<User[]> GetUsers()
    {
        return _storageService.GetAllUsers();
    }

    [Route("/generateGraph")]
    [HttpGet]
    public ActionResult GenerateGraph()
    {
        _userGraphService.GenerateGraph();
        return Ok("graph generated");
    }
    [Route("/getSuggestion")]
    [HttpPost]
    public ActionResult<ConnectionSuggestionResponseModel> GetSuggestion([FromBody] GetSuggestionRequestModel getSuggestionRequestModel)
    {
        return _userGraphService.GetConnectionSuggestion(getSuggestionRequestModel.id, getSuggestionRequestModel.maxDegreeOfConnection, getSuggestionRequestModel.numberOfSugestion);
    }
}