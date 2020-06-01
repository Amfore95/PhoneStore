using System.Collections.Generic;
using System.Linq;

namespace PhoneStore.Models
{
    public class EFProductRepository : IProductRepository 
    {
        private ApplicationDbContext context;

        public EFProductRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IQueryable<Product> Products => context.Products;
    }
}