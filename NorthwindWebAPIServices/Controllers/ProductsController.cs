namespace NorthwindWebAPIServices.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using NorthwindWebAPIServices.Models;

    public class ProductsController : ApiController
    {
        private static readonly ProductsRepository Products = new ProductsRepository();

        public IEnumerable<Product> Get()
        {
            return Products.GetAll();
        }
    }
}
