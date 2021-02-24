using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<int> GetByCategoryCount()
        {
            return new SuccessDataResult<int>(_categoryDal.GetAll().Count);
        }

        public IDataResult<List<Category>> GetById(int categoryId)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(p => p.CategoryId == categoryId));
        }
    }
}
