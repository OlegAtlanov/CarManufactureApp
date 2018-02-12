using CarManufactureApp.Domain;
using CarManufactureApp.Models;
using Ninject;
using System.Linq;
using System.Web.Mvc;

namespace CarManufactureApp.Controllers
{
    public class CarController : Controller
    {
        ICarRepository _repo;

        public CarController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<ICarRepository>().To<CarRepository>();
            _repo = ninjectKernel.Get<ICarRepository>();
        }

        public ActionResult Index(string sortOrder, string searchData)
        {
            ViewBag.SortingName = string.IsNullOrEmpty(sortOrder) ? "Model_Desc" : "";
            ViewBag.SortingDate = sortOrder == "SoldDate" ? "SoldDate_Desc" : "SoldDate";

            var soldCar = _repo.GetAllSoldCar();

            if (!string.IsNullOrEmpty(searchData))
            {
                soldCar = soldCar.Where(c => c.Model.ToUpper().Contains(searchData.ToUpper()));
            }

            switch (sortOrder)
            {
                case "Model_Desc":
                    soldCar = soldCar.OrderByDescending(c => c.Model);
                    break;
                case "SoldDate":
                    soldCar = soldCar.OrderBy(c => c.SoldDate);
                    break;
                case "SoldDate_Desc":
                    soldCar = soldCar.OrderByDescending(c => c.SoldDate);
                    break;
                default:
                    soldCar = soldCar.OrderBy(c => c.Model);
                    break;
            }

            return View(soldCar);
        }
    }
}