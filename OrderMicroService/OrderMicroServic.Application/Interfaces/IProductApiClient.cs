using OrderMicroServic.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroServic.Application.Interfaces;

public interface IProductApiClient
{
	Task<string> GetProductTestAsync();
	Task<List<ProductDTO>> GetProductAllAsync();
}

