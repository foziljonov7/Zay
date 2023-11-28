using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zay.Data.Data;
using Zay.Data.Dtos;
using Zay.Data.Models;
using Zay.Repo.Dtos;
using Zay.Services;

namespace Zay.Repo.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext dbContext;
        private readonly IImageService service;

        public ProductService(AppDbContext dbContext,
            IImageService service)
        {
            this.dbContext = dbContext;
            this.service = service;
        }
        public async Task<Product> CreateProductAsync(CreateProductDto newProduct, IFormFile imageFile)
        {
            var imagePath = service.SaveImage(imageFile);
            var product = dbContext.Products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Name = newProduct.Name,
                Brand = newProduct.Brand,
                Size = newProduct.Size,
                Price = newProduct.Price,
                Color = newProduct.Color,
                Image = imagePath,
                CategoryId = newProduct.CategoryId,
                Description = newProduct.Description
            });

            await dbContext.SaveChangesAsync();
            return await Task.FromResult(product.Entity);
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
                return false;

            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            var product = await dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
                return null;

            return product;
        }

        public async Task<List<Product>> GetProductsAsync()
            => await dbContext.Products.ToListAsync();

        public async Task<Product> UpdateProductAsync(Guid id, UpdateProductDto product)
        {
            var updateProduct = await dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (updateProduct is null)
                return null;

            updateProduct.Name = product.Name;
            updateProduct.Brand = product.Brand;
            updateProduct.Size = product.Size;
            updateProduct.Price = product.Price;
            updateProduct.Color = product.Color;
            updateProduct.Description = product.Description;
            updateProduct.CategoryId = product.CategoryId;
            updateProduct.Description = product.Description;

            await dbContext.SaveChangesAsync();
            return updateProduct;
        }
    }
}
