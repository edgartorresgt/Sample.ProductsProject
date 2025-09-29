using Sample.ProductsSample.Infraestructure.Interfaces;
using Sample.ProductsSample.Infraestructure.Models;

namespace Sample.ProductsSample.Infraestructure.Services;

public class ProductService: IProductService
{
    public async Task<List<ProductModel>> GetProductAsync()
    {
        try
        {
            var products = new List<ProductModel>
            {
                new() { Id = 1, Name = "Product 1", Description = "Description 1", Price = 1},
                new() { Id = 2, Name = "Product 2", Description = "Description 2", Price = 2},
                new() {Id = 3, Name = "Product 3", Description = "Description 3", Price = 3}
            };

            return products;
        }
        catch (Exception e)
        {
          throw new Exception(e.Message);
        }
    }
}