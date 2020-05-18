﻿namespace shop.web.Data.Repositories
{
	using Entities;
    using shop.web.Models;
    using System.Linq;
	using System.Threading.Tasks;

	public interface IOrderRepository : IGenericRepository<Order>
	{
		Task<IQueryable<Order>> GetOrdersAsync(string userName);

		Task<IQueryable<OrderDetailTemp>> GetDetailTempsAsync(string userName);

		Task AddItemToOrderAsync(AddItemViewModel model, string userName);

		Task ModifyOrderDetailTempQuantityAsync(int id, double quantity);
		Task DeleteDetailTempAsync(int id);



	}

}
