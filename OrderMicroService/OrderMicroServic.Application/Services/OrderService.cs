using OrderMicroServic.Application.Interfaces;
using OrderMicroService.Domain.Entities;
using OrderMicroService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroServic.Application.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _repository;

		public OrderService(IOrderRepository repository)
		{
			_repository = repository;
		}
		public Task<IEnumerable<Order>> GetAllAsync() => _repository.GetAllAsync();
		public Task<Order?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
		public Task AddAsync(Order product) => _repository.AddAsync(product);
		public Task UpdateAsync(Order product) => _repository.UpdateAsync(product);
		public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
	}
}
