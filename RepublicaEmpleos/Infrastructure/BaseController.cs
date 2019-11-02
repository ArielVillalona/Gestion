using Microsoft.AspNetCore.Mvc;

namespace RepublicaEmpleos.Infrastructure
{
    [Route("[controller]/[action]", Name = "[controller]_[action]")]
    public abstract class BaseController : Controller
    {
    }
}
