using GoodHealth.CroosCuttimg.Ioc;
using Microsoft.AspNetCore.Mvc;

namespace GoodHealth.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected IValidationResultBuilder _validationResultBuilder;
        public BaseController(IValidationResultBuilder validationResultBuilder)
        {
            _validationResultBuilder = validationResultBuilder;
        }
    }
}
