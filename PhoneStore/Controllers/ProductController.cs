using Microsoft.AspNetCore.Mvc;
using PhoneStore.Models;
using System.Linq;
using PhoneStore.Models.ViewModels;

namespace PhoneStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository _repository)
        {
            repository = _repository;
        }

        public ViewResult List(string category, int productPage = 1)
            => View(new ProductListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.Id)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Products.Count() : repository.Products
                            .Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            });
    }
}