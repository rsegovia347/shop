using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.web.Data
{
	using Entities;

	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(DataContext context) : base(context)
		{
		}
	}


}
