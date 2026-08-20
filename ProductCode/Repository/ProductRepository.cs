using ProductCode.Model;
using ProductCode.Repository.Interface;
using ProductCode.Utilities;
namespace ProductCode.Repository;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products =
    [
        new Product
        {
            Id = 1,
            ProductCode = ProductCodeGenerator.Generate(),
            Name = "iPhone 17 Pro",
            Price = 39900,
            Stock = 10
        },
        new Product
        {
            Id = 2,
            ProductCode = ProductCodeGenerator.Generate(),
            Name = "MacBook Air",
            Price = 42900,
            Stock = 5
        },
        new Product
        {
            Id = 3,
            ProductCode = ProductCodeGenerator.Generate(),
            Name = "iPad Pro",
            Price = 35900,
            Stock = 8
        }
    ];

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Product>>(_products);
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        return Task.FromResult(_products.FirstOrDefault(x => x.Id == id));
    }

    public Task AddAsync(Product product)
    {
        product.Id = _products.Count == 0
            ? 1
            : _products.Max(x => x.Id) + 1;

        product.ProductCode = ProductCodeGenerator.Generate();

        _products.Add(product);

        return Task.FromResult(product);
    }

    public Task UpdateAsync(Product product)
    {
        var existing = _products.FirstOrDefault(x => x.Id == product.Id);

        if (existing == null)
            return Task.FromResult(false);

        existing.Name = product.Name;
        existing.Price = product.Price;
        existing.Stock = product.Stock;

        return Task.FromResult(true);
    }

    public Task DeleteAsync(int id)
    {
        var product = _products.FirstOrDefault(x => x.Id == id);

        if (product == null)
            return Task.FromResult(false);

        _products.Remove(product);

        return Task.FromResult(true);
    }
}