using Microsoft.AspNetCore.Mvc;
using ProductMicroService.Application.Interfaces;
using ProductMicroService.Application.Services;
using ProductMicroService.Domain.Entities;

namespace ProductMicroService.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
	private readonly IProductService _service;

	public ProductController(IProductService service)
	{
		_service = service;
	}

	[HttpGet("GetTest")]
	public IActionResult GetTest()
	{
		return Ok("Test Is Ok");
	}

	[HttpGet]
	public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(int id)
	{
		var product = await _service.GetByIdAsync(id);
		return product is null ? NotFound() : Ok(product);
	}

	[HttpPost]
	public async Task<IActionResult> Create(Product product)
	{
		await _service.AddAsync(product);
		return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(int id, Product product)
	{
		if (id != product.Id) return BadRequest();
		await _service.UpdateAsync(product);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		await _service.DeleteAsync(id);
		return NoContent();
	}
}

