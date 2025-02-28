using Microsoft.AspNetCore.Mvc;
using DHL.Shared;

[ApiController]
[Route("api/data")]
public class DataController : ControllerBase
{
    [HttpGet]
    public ActionResult<DataModel> GetData()
    {
        return Ok(new DataModel { Message = "Toto je odpověď z API!" });
    }
}
