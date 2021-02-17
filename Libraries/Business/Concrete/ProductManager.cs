using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 12)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime, null);
            }
            var products = _productDal.GetAll();

            return new SuccessDataResult<List<Product>>(Messages.ProductsListed, products);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            var products = _productDal.GetAll(p => p.CategoryId == id);

            return new SuccessDataResult<List<Product>>(Messages.ProductGetAllByCategory, products);
        }

        public IDataResult<Product> GetById(int productId)
        {
            var product = _productDal.Get(p => p.ProductId == productId);

            return new SuccessDataResult<Product>(Messages.ProductGet, product);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            var products = _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);

            return new SuccessDataResult<List<Product>>(Messages.ProductGetByUnitPrice, products);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            var productDetails = _productDal.GetProductDetails();

            return new SuccessDataResult<List<ProductDetailDto>>(Messages.ProductGetProductDetails, productDetails);
        }
    }
}