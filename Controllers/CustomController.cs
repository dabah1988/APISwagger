using Microsoft.AspNetCore.Mvc;

namespace CityManager.WebAPI.Controllers
{
    /// <summary>
    /// pour le point d'entrée des versions
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomController : ControllerBase
    {
     
    }
}
 