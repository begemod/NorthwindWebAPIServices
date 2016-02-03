namespace NorthwindWebAPIServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductsRepository
    {
        private IList<Product> _products;

        private int _maxId;

        public ProductsRepository()
        {
            _products = new List<Product>
                            {
                                new Product { Id = 1, Name = "Bread", Category = "Food", Price = 22m },
                                new Product { Id = 2, Name = "Milk", Category = "Food", Price = 47m },
                                new Product { Id = 3, Name = "Car", Category = "Vehicle", Price = 100500m },
                                new Product { Id = 4, Name = "Phone", Category = "Hardware", Price = 999.99m },
                                new Product { Id = 5, Name = "Hat", Category = "Wear", Price = 250m }
                            };

            _maxId = 5;
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(P => P.Id == id);
        }

        public IEnumerable<Product> GetByCategory(string category)
        {
            return _products.Where(P => string.Equals(category, P.Category, StringComparison.CurrentCultureIgnoreCase));
        }

        public Product Add(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product");
            }

            _maxId++;
            product.Id = _maxId;

            _products.Add(product);

            return product;
        }

        public bool Update(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product");
            }
            
            var storedProduct = _products.FirstOrDefault(P => P.Id == product.Id);

            if (storedProduct == null)
            {
                return false;
            }

            storedProduct.Name = product.Name;
            storedProduct.Category = product.Category;
            storedProduct.Price = product.Price;

            return true;
        }

        public bool Delete(int id)
        {
            var storedProduct = _products.FirstOrDefault(P => P.Id == id);

            if (storedProduct == null)
            {
                return false;
            }

            _products.Remove(storedProduct);

            return true;


        }
    }
}