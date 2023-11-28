using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zay.Data.Dtos;
using Zay.Data.Models;
using Zay.Repo.Dtos;

namespace Zay.Repo.Services
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
