using Microsoft.EntityFrameworkCore;
using OrderMicroService.Domain.Entities;
using OrderMicroService.Domain.Interfaces;
using OrderMicroService.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
	private readonly OrderDBContext _context;

	public OrderRepository(OrderDBContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Order>> GetAllAsync() => await _context.Orders.ToListAsync();

	public async Task<Order?> GetByIdAsync(int id) => await _context.Orders.FindAsync(id);

	public async Task AddAsync(Order product)
	{
		_context.Orders.Add(product);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Order product)
	{
		_context.Orders.Update(product);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var product = await _context.Orders.FindAsync(id);
		if (product is not null)
		{
			_context.Orders.Remove(product);
			await _context.SaveChangesAsync();
		}
	}
}

