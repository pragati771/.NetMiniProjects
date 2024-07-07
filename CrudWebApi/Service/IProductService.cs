using FullStackPK.Entities;

namespace FullStackPK.Service
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product Insert(Product p);
        String Update(int id,Product p);
        string DeleteById(int id);
        Product GetById(int id);
    }
}
