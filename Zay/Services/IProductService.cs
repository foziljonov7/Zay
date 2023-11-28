using Zay.Data.Dtos;
using Zay.Data.Models;

namespace Zay.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(Guid id);
        Task<Product> CreateProductAsync(CreateProductDto newProduct, IFormFile imageFile);
        Task<Product> UpdateProductAsync(Guid id, UpdateProductDto product);
        Task<bool> DeleteProductAsync(Guid id);
    }
}
