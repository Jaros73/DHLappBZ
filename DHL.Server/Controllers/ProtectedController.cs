using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

[Microsoft.AspNetCore.Mvc.Route("api/protected")]
[ApiController]
public class ProtectedController : ControllerBase
{
    [Authorize]
    [HttpGet("data")]
    public IActionResult GetData()
    {
        return Ok(new { Message = "Toto jsou chráněná data, dostupná jen přihlášeným uživatelům." });
    }

    [Authorize(Roles = "Dispecink")]
    [HttpGet("dispatch-only")]
    public IActionResult DispatchOnlyData()
    {
        return Ok(new { Message = "Toto je dostupné jen pro dispečery." });
    }
}
