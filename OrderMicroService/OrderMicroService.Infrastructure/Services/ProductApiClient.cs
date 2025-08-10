using OrderMicroServic.Application.DTOs;
using OrderMicroServic.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderMicroService.Infrastructure.Services;

public class ProductApiClient : IProductApiClient
{
	private readonly HttpClient httpClient;

	public ProductApiClient(HttpClient httpClient)
	{
		this.httpClient = httpClient;
	}

	public async Task<string> GetProductTestAsync()
	{
		var response = await httpClient.GetAsync("api/Product/GetTest");
		response.EnsureSuccessStatusCode();

		return await response.Content.ReadAsStringAsync();
	}

	public async Task<List<ProductDTO>> GetProductAllAsync()
	{
		var response = await httpClient.GetAsync("api/Product/GetAll");
		response.EnsureSuccessStatusCode();

		var json = await response.Content.ReadAsStringAsync();

		var product =  JsonSerializer.Deserialize<List<ProductDTO>>(json);

		if (product == null)
		{
			throw new InvalidOperationException("Failed to deserialize product from API response.");
		}

		return product;
	}
}

