using Microsoft.AspNetCore.Mvc;

namespace VyasApi.Controllers
{
	[ApiController]
	[Route("")]
	public class HomeController : ControllerBase
	{
		[HttpGet("healthcheck")]
		public IActionResult HealthCheck()
		{
			return Ok(new
			{
				code = "success",
				message = "success"
			});
		}

		[HttpGet("version")]
		public IActionResult Version()
		{
			var version = GetType().Assembly.GetName().Version;
			return Ok(new
			{
				version = version
			});
		}
	}
}