using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using ProductSystem.Core.Aspects.Autofac.Validation;
using ProductSystem.Core.Utilities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            IResult result = BusinessRules.Run(CheckCategoryName(category.CategoryName), CheckCategoryCount());
            if (result != null)
            {
                return result;
            }
            _categoryDal.Add(category);
            return new SuccessResult(Messages.AddCategory);
           
            
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.DeleteCategory);
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(x => x.Id == categoryId));
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.UpdateCategory);
        }
        //İş kodumuz : Aynı isimli kategori eklenemez.
        private IResult CheckCategoryName(string categoryName)
        {
            var result = _categoryDal.GetList(c => c.CategoryName == categoryName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CategoryNameAlreadyExists);
            }
            return new SuccessResult();
        }

        //İş kodumuz : 7 den fazla kategori eklenemesin.

        private IResult CheckCategoryCount()
        {
            var result = _categoryDal.GetList();
            if (result.Count > 7)
            {
                return new ErrorResult(Messages.CategoryCount);
            }
            return new SuccessResult();
        }
      
    }
}
