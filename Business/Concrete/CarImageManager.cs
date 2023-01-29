using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelperService _fileHelperService;
        string _root = "wwwroot\\Uploads\\Images\\";

        public CarImageManager(ICarImageDal carImageDal, IFileHelperService fileHelperService)
        {
            _carImageDal = carImageDal;
            _fileHelperService = fileHelperService;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelperService.RePath(file);
            _fileHelperService.Upload(file, _root, carImage.ImagePath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelperService.Delete(_root + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            string newFilePath = _fileHelperService.RePath(file);
            _fileHelperService.Update(file, _root + carImage.ImagePath, newFilePath, _root);

            carImage.ImagePath = newFilePath;
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var filteredImages = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(filteredImages);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var filteredImages = _carImageDal.GetAll(c => c.CarId == carId);
            return new SuccessDataResult<List<CarImage>>(filteredImages);
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            var filteredImage = _carImageDal.Get(c => c.Id == imageId);
            return new SuccessDataResult<CarImage>(filteredImage);
        }


    }
}
