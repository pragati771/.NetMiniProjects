using FullStackPK.Entities;
using FullStackPK.Reposatories;
namespace FullStackPK.Service
{
    public class ProductService : IProductService
    {
        public IProductRepo _iproductrepo;
        public ProductService(IProductRepo ipo) {
            _iproductrepo= ipo;
        }

        public string DeleteById(int id)
        {
            return _iproductrepo.DeleteById(id);
        }

        public List<Product> GetAll() { 
           return _iproductrepo.GetAll();
        }

        public Product GetById(int id)
        {
            return _iproductrepo.GetById(id);
        }

        public Product Insert(Product p)
        {
            return _iproductrepo.Insert(p);
        }

        public String Update(int id,Product p)
        {
            return _iproductrepo.Update(id,p);
        }
    }
}
