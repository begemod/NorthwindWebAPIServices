namespace NorthwindWebAPIServices.Models
{
    using System.Collections.Generic;
    using NorthwindWebAPIServices.Models.Entities;

    public interface IProductsRepository
    {
        IEnumerable<Product> GetAll();

        Product GetById(int id);

        IEnumerable<Product> GetByCategory(string category);

        Product Add(Product product);

        bool Update(Product product);

        bool Delete(int id);
    }
}
