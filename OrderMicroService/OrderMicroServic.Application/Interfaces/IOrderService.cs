using OrderMicroService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroServic.Application.Interfaces;

public interface IOrderService
{
	Task<IEnumerable<Order>> GetAllAsync();
	Task<Order?> GetByIdAsync(int id);
	Task AddAsync(Order product);
	Task UpdateAsync(Order product);
	Task DeleteAsync(int id);
}

