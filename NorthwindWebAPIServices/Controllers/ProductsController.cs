namespace NorthwindWebAPIServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using NorthwindWebAPIServices.Models;
    using NorthwindWebAPIServices.Models.Entities;

    public class ProductsController : ApiController
    {
        private readonly IProductsRepository products;

        public ProductsController(IProductsRepository products)
        {
            this.products = products;
        }

        public IEnumerable<Product> Get()
        {
            return products.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var product = products.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // api/products?category=Foods
        public IEnumerable<Product> GetByCategory(string category)
        {
            return products.GetByCategory(category);
        }

        public HttpResponseMessage Post(Product product)
        {
            var addedProduct = products.Add(product);

            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, product);

            string uri = Url.Link("DefaultApi", new { id = product.Id });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        public IHttpActionResult Put(int id, Product product)
        {
            product.Id = id;
            if (!products.Update(product))
            {
                return NotFound();
            }

            return Ok(product);
        }

        public void Delete(int id)
        {
            if (!products.Delete(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
