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
            IProductService productService = new ProductManager(new EfProductDal());

            var productList = productService.GetAllByCategoryId(2);

            productList.ForEach(p => Console.WriteLine(p.ProductName));

            Console.ReadLine();
        }
    }
}
