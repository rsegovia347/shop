using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.web.Data
{
    using Entities;

    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable GetAllWithUsers();
    }

}
