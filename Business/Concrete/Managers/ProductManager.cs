using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcern.Validation.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidate(typeof(ProductValidator))]
        public Product Add(Product product)
        {
            
            return _productDal.Add(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidate(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            
            return _productDal.Update(product);
        }
    }
}
