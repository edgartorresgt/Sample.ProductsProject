using Moq;
using Sample.ProductsSample.Infraestructure.Interfaces;

namespace Sample.ProductsProject.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetProducts_RequestProducts_SuccessfullResponse()
        {
            //Arrange 
            var productService = new Mock<IProductService>();
            productService.Setup(x => x.GetProductAsync())
                .ReturnsAsync([new() { Id = 1, Name = "Product test", Description = "Product Description", Price = 1} ]);

            //Act 
            var result = await productService.Object.GetProductAsync();

            //Assert
            Assert.NotEmpty( result);
            Assert.Equal(1, result.Count());
            Assert.Equal("Product test", result.FirstOrDefault().Name);
        }
    }
}