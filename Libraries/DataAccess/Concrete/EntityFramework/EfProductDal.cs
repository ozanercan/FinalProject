using Core.DataAccess.EntityRepository.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            NorthwindContext context = new NorthwindContext();

            var result = from p in context.Products
                         join c in context.Categories
                         on p.CategoryId equals c.CategoryId
                         select new ProductDetailDto
                         {
                             ProductID = p.ProductId,
                             CategoryName = c.CategoryName,
                             ProductName = p.ProductName,
                             UnitsInStock = p.UnitsInStock
                         };

            return result.ToList();
        }
    }
}
