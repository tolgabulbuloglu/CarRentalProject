

using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;



CarManager carManager = new CarManager(new EfCarDal());

carManager.GetAll();


