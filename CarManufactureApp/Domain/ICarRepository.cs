using CarManufactureApp.Models;
using System.Linq;

namespace CarManufactureApp.Domain
{
    interface ICarRepository : IRepository<Car>
    {
        IQueryable<Car> GetAllSoldCar();
    }
}
