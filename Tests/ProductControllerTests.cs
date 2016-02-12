namespace Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Results;
    using Moq;
    using NorthwindWebAPIServices.Controllers;
    using NorthwindWebAPIServices.Models;
    using NorthwindWebAPIServices.Models.Entities;
    using NUnit.Framework;

    [TestFixture]
    public class ProductControllerTests
    {
        [Test]
        public void GetAllTest()
        {
            var testProducts = this.GetTestProducts();
            var productRepositoryMock = Mock.Of<IProductsRepository>(R => R.GetAll() == testProducts);

            var productsController = new ProductsController(productRepositoryMock);
            var allProducts = productsController.Get();

            Assert.That(allProducts, Is.Not.Empty);
            Assert.That(allProducts.Count(), Is.EqualTo(testProducts.Count));
        }

        [Test]
        public void GetByIdTest()
        {
            var testProducts = this.GetTestProducts();
            var productId = testProducts.First().Id;

            var productRepositoryMock = new Mock<IProductsRepository>();
            productRepositoryMock.Setup(R => R.GetById(productId)).Returns(testProducts.First(P => P.Id == productId));

            var productsController = new ProductsController(productRepositoryMock.Object);

            var result = productsController.Get(productId) as OkNegotiatedContentResult<Product>;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Content, Is.Not.Null);
            Assert.That(result.Content.Id,Is.EqualTo(productId));
        }

        private IList<Product> GetTestProducts()
        {
            return new List<Product>
                            {
                                new Product { Id = 1, Name = "Bread", Category = "Food", Price = 22m },
                                new Product { Id = 2, Name = "Milk", Category = "Food", Price = 47m },
                                new Product { Id = 3, Name = "Car", Category = "Vehicle", Price = 100500m },
                                new Product { Id = 4, Name = "Phone", Category = "Hardware", Price = 999.99m },
                                new Product { Id = 5, Name = "Hat", Category = "Wear", Price = 250m }
                            };
        }
    }
}
