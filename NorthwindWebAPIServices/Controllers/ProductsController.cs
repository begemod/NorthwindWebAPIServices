namespace NorthwindWebAPIServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using NorthwindWebAPIServices.Models;

    public class ProductsController : ApiController
    {
        private static readonly ProductsRepository Products = new ProductsRepository();

        public IEnumerable<Product> Get()
        {
            return Products.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var product = Products.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // api/products?category=Foods
        public IEnumerable<Product> GetByCategory(string category)
        {
            return Products.GetByCategory(category);
        }

        public HttpResponseMessage Post(Product product)
        {
            var addedProduct = Products.Add(product);

            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, product);

            string uri = Url.Link("DefaultApi", new { id = product.Id });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        public IHttpActionResult Put(int id, Product product)
        {
            product.Id = id;
            if (!Products.Update(product))
            {
                return NotFound();
            }

            return Ok(product);
        }

        public void Delete(int id)
        {
            if (!Products.Delete(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
