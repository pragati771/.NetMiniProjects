using FullStackPK.Entities;

namespace FullStackPK.Reposatories
{
    public interface IProductRepo
    {
        List<Product> GetAll();
        Product Insert(Product product);
        String Update(int id,Product product);
        string DeleteById(int id);
        Product GetById(int id);
    }
}
