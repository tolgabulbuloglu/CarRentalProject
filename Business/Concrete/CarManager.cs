using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            ValidationTool.Validate(new CarValidator(), car);


            if (DateTime.Now.Hour == 11)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            //İş kodları ......
            // ...........

            var filteredCars = _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(filteredCars, Messages.EntitiesListed);

        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            var filteredCars = _carDal.GetAll(c => c.BrandId == brandId);
            return new SuccessDataResult<List<Car>>(filteredCars, Messages.EntitiesListedByFilter);
        }

        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            var filteredCars = _carDal.GetAll(c => c.ColorId == colorId);
            return new SuccessDataResult<List<Car>>(filteredCars, Messages.EntitiesListedByFilter);
        }

        public IDataResult<Car> GetById(int id)
        {
            var filteredCar = _carDal.Get(c => c.Id == id);
            return new SuccessDataResult<Car>(filteredCar, Messages.EntitiesListedByFilter);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var filteredCarDetails = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(filteredCarDetails, Messages.EntitiesListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}
