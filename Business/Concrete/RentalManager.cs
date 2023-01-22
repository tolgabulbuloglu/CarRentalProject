using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            _rentalDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var filteredRentals = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(filteredRentals);
        }

        public IDataResult<Rental> GetById(int id)
        {
            var filteredRental = _rentalDal.Get(c => c.Id == id);
            return new SuccessDataResult<Rental>(filteredRental);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            var filteredRentalDtos = _rentalDal.GetRentalDetails();
            return new SuccessDataResult<List<RentalDetailDto>>(filteredRentalDtos);
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult();
        }
    }
}
