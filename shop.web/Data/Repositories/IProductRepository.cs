using System.Collections.Generic;
using System.Linq;

namespace shop.web.Data
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable GetAllWithUsers();
        IEnumerable<SelectListItem> GetComboProducts();

    }

}
