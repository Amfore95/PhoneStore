using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using PhoneStore.Models;
using PhoneStore.Controllers;
using PhoneStore.Models.ViewModels;

namespace PhoneStore.Test
{
    public class ProductControllerTest
    {
        [Fact]
        public void Can_Paginate()
        {
            //Arange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product { Id = 1, Title = "P1"},
                new Product { Id = 2, Title = "P2"},
                new Product { Id = 3, Title = "P3"},
                new Product { Id = 4, Title = "P4"},
                new Product { Id = 5, Title = "P5"},
            }).AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Act
            ProductListViewModel result = controller.List(null, 2).ViewData.Model as ProductListViewModel;

            //Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Title);
            Assert.Equal("P5", prodArray[1].Title);
        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            //Arange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {Id = 1, Title = "P1"},
                new Product {Id = 2, Title = "P2"},
                new Product {Id = 3, Title = "P3"},
                new Product {Id = 4, Title = "P4"},
                new Product {Id = 5, Title = "P5"}
            }).AsQueryable<Product>());

            //Arange
            ProductController controller = new ProductController(mock.Object) { PageSize = 3 };

            //Act 
            ProductListViewModel result = controller.List(null, 2).ViewData.Model as ProductListViewModel;

            //Asert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }

        [Fact]
        public void Can_Filter_Products()
        {
            //Arrange
            //-create the mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product { Id = 1, Title = "P1", Category = "Cat1"},
                new Product { Id = 2, Title = "P2", Category = "Cat2"},
                new Product { Id = 3, Title = "P3", Category = "Cat1"},
                new Product { Id = 4, Title = "P4", Category = "Cat2"},
                new Product { Id = 5, Title = "P5", Category = "Cat3"}
            }).AsQueryable<Product>());

            //Arange - create a controller and make the page size 3 items
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Action
            Product[] result = (controller.List("Cat2", 1).ViewData.Model as ProductListViewModel)
                .Products.ToArray();

            //Assert
            Assert.Equal(2, result.Length);
            Assert.True(result[0].Title == "P2" && result[0].Category == "Cat2");
            Assert.True(result[1].Title == "P4" && result[1].Category == "Cat2");
        }
    }
}