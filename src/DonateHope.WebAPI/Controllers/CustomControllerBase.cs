using Microsoft.AspNetCore.Mvc;

namespace DonateHope.WebAPI.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class CustomControllerBase : ControllerBase { }
