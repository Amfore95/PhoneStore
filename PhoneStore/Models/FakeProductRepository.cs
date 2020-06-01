using System.Collections.Generic;
using System.Linq;

namespace PhoneStore.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product {Title = "Samsung A9", Price = 25990},
            new Product {Title = "Nokia Lumia 650", Price = 9990},
            new Product {Title = "IPhone 10", Price = 99090}
        }.AsQueryable<Product>();
    }
}