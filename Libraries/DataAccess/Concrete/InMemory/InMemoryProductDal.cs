using Core.DataAccess.EntityRepository.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    CategoryId = 1,
                    ProductName = "Bardak",
                    UnitPrice = 15,
                    UnitsInStock = 15
                },
                new Product()
                {
                    ProductId = 2,
                    CategoryId = 1,
                    ProductName = "Kamera",
                    UnitPrice = 500,
                    UnitsInStock = 3
                },
                new Product()
                {
                    ProductId = 3,
                    CategoryId = 2,
                    ProductName = "Telefon",
                    UnitPrice = 1500,
                    UnitsInStock = 2
                },
                new Product()
                {
                    ProductId = 4,
                    CategoryId = 2,
                    ProductName = "Klavye",
                    UnitPrice = 150,
                    UnitsInStock = 65
                },
                new Product()
                {
                    ProductId = 5,
                    CategoryId = 2,
                    ProductName = "Fare",
                    UnitPrice = 85,
                    UnitsInStock = 1
                }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public bool Commit()
        {
            throw new NotImplementedException();
        }

        public bool CreateBulk(List<Product> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            Product productToDelete;

            productToDelete = _products.Where(p => p.ProductId == product.ProductId).SingleOrDefault();

            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> expression, params Expression<Func<Product, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> exp = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> expression = null, params Expression<Func<Product, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate;

            productToUpdate = _products.Where(p => p.ProductId == product.ProductId).SingleOrDefault();

            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        bool IEntityRepository<Product>.Add(Product entity)
        {
            throw new NotImplementedException();
        }

        bool IEntityRepository<Product>.Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        bool IEntityRepository<Product>.Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
