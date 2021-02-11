using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetProducts();

            //GetCategories();

            GetProductDetails();

            Console.ReadLine();
        }

        private static void GetProductDetails()
        {
            IProductService productService = new ProductManager(new EfProductDal());

            var productDetailsResult = productService.GetProductDetails();

            if (productDetailsResult.Success)
            {
                productDetailsResult.Data.ForEach(p =>
                {
                    Console.WriteLine($"Product Id: {p.ProductID} \nCategory: {p.CategoryName}\nProduct: {p.ProductName}\nStock: {p.UnitsInStock}");
                    Console.WriteLine("-----------------------------------------");
                });
            }
            else
            {
                Console.WriteLine(productDetailsResult.Message);
            }
        }

        private static void GetCategories()
        {
            ICategoryService categoryService = new CategoryManager(new EfCategoryDal());

            var categories = categoryService.GetAll();

            categories.ForEach(category => Console.WriteLine(category.CategoryName));
        }

        private static void GetProducts()
        {
            IProductService productService = new ProductManager(new EfProductDal());

            var productList = productService.GetAllByCategoryId(2);

            productList.Data.ForEach(p => Console.WriteLine(p.ProductName));
        }
    }
}
