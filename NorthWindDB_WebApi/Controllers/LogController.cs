
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NorthWindDB_WebApi.Controllers
{
 [Route("api/logs")] // Specify the fixed route
[ApiController]
public class LogController : ControllerBase
{
    private readonly ILog log = LogManager.GetLogger("API Logger");

        [HttpGet]
    public IEnumerable<string> Get()
    {
        log.Info("Log Info Message");
        log.Debug("Log Debug Message");
        log.Error("Log Error Message");
        log.Warn("Log Warning Message");

        return new string[] { "value1", "value2" };
    }
}

}
