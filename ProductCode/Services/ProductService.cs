using ProductCode.Model;
using ProductCode.Repository.Interface;
using ProductCode.Services.Interface;
using ProductCode.Repository;
namespace ProductCode.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public List<Product> GetAll()
    {
        return _repository.GetAllAsync().Result.ToList();
    }

    public Product? GetById(int id)
    {
        return _repository.GetByIdAsync(id).Result;
    }

    public Product Create(Product product)
    {
        _repository.AddAsync(product).Wait();
        return product;
    }

    public bool Update(int id, Product product)
    {
        return _repository.UpdateAsync(product).IsCompleted;
    }

    public bool Delete(int id)
    {
        return _repository.DeleteAsync(id).IsCompleted;
    }
}