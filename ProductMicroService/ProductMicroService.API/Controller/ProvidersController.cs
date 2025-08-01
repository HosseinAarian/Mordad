using Microsoft.AspNetCore.Mvc;
using ProductMicroService.Utilities.ExternalApiServicces;

namespace ProductMicroService.API.Controller
{
	public class ProvidersController : ControllerBase
	{
		private readonly ExternalApiService externalApiService;

		public ProvidersController(ExternalApiService externalApiService)
		{
			this.externalApiService = externalApiService;
		}

		[HttpGet("call")]
		public async Task<IActionResult> CallExternalApi()
		{
			await externalApiService.CallAndLogApiAsync("https://api.publicapis.org/entries");
			return Ok("API call logged.");
		}
	}
}
