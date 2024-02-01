using Microsoft.AspNetCore.Mvc;
using SocialMedia.Abstraction;
using SocialMedia.Models.BusinessModels;
using SocialMedia.Models.RequestModel;

namespace SocialMedia.Controllers;

[ApiController]
[Route("Network")]
public class NetworkController : ControllerBase
{
    private readonly IStorageService _storageService;

    public NetworkController(IStorageService storageService)
    {
        _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
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
}