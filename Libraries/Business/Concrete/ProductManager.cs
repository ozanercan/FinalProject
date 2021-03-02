using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //Aynı isimde ürün eklenemez

            IResult result = BusinessRules.Run(
                CheckIfProductNameExists(product.ProductName),
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfCategoryLimitExceded()
                );

            //Eğer mevcut kategori sayısı 15'i geçtiyse sisteme yeni ürün eklenemez.

            if (result != null)
                return result;

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 12)
            {
                return new ErrorDataResult<List<Product>>(null, Messages.MaintenanceTime);
            }
            var products = _productDal.GetAll();

            return new SuccessDataResult<List<Product>>(products, Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            var products = _productDal.GetAll(p => p.CategoryId == id);

            return new SuccessDataResult<List<Product>>(products, Messages.ProductGetAllByCategory);
        }

        public IDataResult<Product> GetById(int productId)
        {
            var product = _productDal.Get(p => p.ProductId == productId);

            return new SuccessDataResult<Product>(product, Messages.ProductGet);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            var products = _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);

            return new SuccessDataResult<List<Product>>(products, Messages.ProductGetByUnitPrice);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            var productDetails = _productDal.GetProductDetails();

            return new SuccessDataResult<List<ProductDetailDto>>(productDetails, Messages.ProductGetProductDetails);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            {
                _productDal.Update(product);

                return new SuccessResult(Messages.ProductUpdated);
            }

            return new ErrorResult();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var productsCount = _productDal.GetAll(p => p.CategoryId == categoryId).Count;

            if (productsCount >= 10)
                return new ErrorResult(Messages.ProductCountOfCategoryError);

            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var categoryCountResult = _categoryService.GetByCategoryCount();

            if (!categoryCountResult.Success)
                return new ErrorResult(Messages.CategoryCountError);

            if (categoryCountResult.Data >= 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName.Equals(productName)).Any();
            if (result)
                return new ErrorResult(Messages.ProductNameAlreadyExists);

            return new SuccessResult();
        }
    }
}