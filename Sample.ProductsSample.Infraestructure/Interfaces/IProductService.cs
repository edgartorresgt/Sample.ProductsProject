using Sample.ProductsSample.Infraestructure.Models;

namespace Sample.ProductsSample.Infraestructure.Interfaces;

public interface IProductService
{
    public Task<List<ProductModel>> GetProductAsync();
}