using System.Linq;

namespace PhoneStore.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}