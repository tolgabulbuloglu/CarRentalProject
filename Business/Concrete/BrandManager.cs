﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var filteredBrands = _brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>(filteredBrands, Messages.EntitiesListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            var filteredBrand= _brandDal.Get(b=> b.Id==id);
            return new SuccessDataResult<Brand>(filteredBrand, Messages.EntitiesListedByFilter);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}
