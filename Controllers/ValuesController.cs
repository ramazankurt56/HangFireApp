using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangFireApp.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpPost]
    public IActionResult Get()
    {
        BackgroundJob.Enqueue(()=>EmailService.SendEmail("example@example.com", "Hello!"));
        return Ok("Successful");
    }
}
public class EmailService
{
    public static void SendEmail(string email, string message)
    {
        Console.WriteLine($"Email sent: {email}, Content: {message}");
    }
}