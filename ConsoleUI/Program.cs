

using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//InMemoryConsoleCodes();

CarManager carManager = new CarManager(new EfCarDal());

carManager.GetAll();









static void InMemoryConsoleCodes()
{
    CarManager carManager = new CarManager(new InMemoryCarDal());
    List<Car> carList = carManager.GetAll();

    foreach (var item in carList)
    {
        Console.WriteLine(item.Description);
    }

    Console.WriteLine("-----------------------------");

    Car car4 = new Car
    {
        Id = 4,
        BrandId = 3,
        ColorId = 2,
        DailyPrice = 1500,
        ModelYear = 2022,
        Description = "Mazda 3"
    };

    carManager.Add(car4);

    foreach (var item in carList)
    {
        Console.WriteLine(item.Description);
    }

    Console.WriteLine("-----------------------------");

    carManager.Update(new Car { Id = 2, Description = "Toyota Nazlı" });

    foreach (var item in carList)
    {
        Console.WriteLine(item.Description);
    }

    Console.WriteLine("-----------------------------");



    carManager.Delete(new Car { Id = 2 });

    foreach (var item in carList)
    {
        Console.WriteLine(item.Description);
    }

    Console.WriteLine("-----------------------------");
}