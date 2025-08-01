using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroService.Utilities.ExternalApiServicces
{
	public class ExternalApiService
	{
		private readonly HttpClient httpClient;
		private readonly ILogger<ExternalApiService> logger;

		public ExternalApiService(HttpClient httpClient, ILogger<ExternalApiService> logger)
		{
			this.httpClient = httpClient;
			this.logger = logger;
		}

		public async Task CallAndLogApiAsync(string apiUrl)
		{
			try
			{
				logger.LogInformation("Calling external API: {Url}", apiUrl);

				HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
				response.EnsureSuccessStatusCode();

				string responseBody = await response.Content.ReadAsStringAsync();

				logger.LogInformation("API Response: {Response}", responseBody);
			}
			catch (HttpRequestException ex)
			{
				logger.LogError(ex, "Error calling API: {Url}", apiUrl);
			}
		}
	}
}
