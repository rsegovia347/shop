using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.web.Data
{
	using Entities;
	using Microsoft.EntityFrameworkCore;

	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(DataContext context) : base(context)
		{
			Context = context;
		}

		public DataContext Context { get; }

		public IQueryable GetAllWithUsers()
		{
			return this.Context.Products.Include(p=>p.User);
		}
	}


}
