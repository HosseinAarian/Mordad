using Microsoft.AspNetCore.Mvc;
using OrderMicroServic.Application.Interfaces;
using OrderMicroService.Domain.Entities;

namespace OrderMicroService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
	private readonly IOrderService _service;
	private readonly IProductApiClient productApiClient;

	public OrderController(IOrderService service, IProductApiClient productApiClient)
	{
		_service = service;
		this.productApiClient = productApiClient;
	}

	[HttpGet("GetAll")]
	public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(int id)
	{
		var product = await _service.GetByIdAsync(id);
		return product is null ? NotFound() : Ok(product);
	}

	[HttpPost]
	public async Task<IActionResult> Create(Order order)
	{
		await _service.AddAsync(order);
		return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(int id, Order order)
	{
		if (id != order.Id) return BadRequest();
		await _service.UpdateAsync(order);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		await _service.DeleteAsync(id);
		return NoContent();
	}

	#region Product APICall
	[HttpGet("GetProductTest")]
	public async Task<IActionResult> GetProductTest()
	{
		var result = await productApiClient.GetProductTestAsync();
		return Ok(result);	
	}

	[HttpGet("GetProductAllTest")]
	public async Task<IActionResult> GetProductAll()
	{
		var resuly = await productApiClient.GetProductAllAsync();
		return Ok(resuly);
	}
	#endregion
}

