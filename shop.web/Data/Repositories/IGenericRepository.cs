﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.web.Data
{
	public interface IGenericRepository<T> where T : class
	{
		IQueryable<T> GetAll();

		Task<T> GetByIdAsync(int id);

		Task<T> CreateAsync(T entity);

		Task<T> UpdateAsync(T entity);


		Task DeleteAsync(T entity);

		Task<bool> ExistAsync(int id);
	}

}
