using shop.web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.web.Data
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
	{
		public CountryRepository(DataContext context) : base(context)
		{
		}
	}
}
