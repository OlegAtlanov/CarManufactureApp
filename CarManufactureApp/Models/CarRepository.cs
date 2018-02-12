using CarManufactureApp.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CarManufactureApp.Models
{
    public class CarRepository : ICarRepository
    {
        DBModel _db;

        public CarRepository()
        {
            string path = WebConfigurationManager.AppSettings["jsonPath"];
            var directlyPath = HttpContext.Current.Server.MapPath("/") + path;

            if (File.Exists(directlyPath))
            {
                string json = File.ReadAllText(directlyPath);
                var cars = JsonConvert.DeserializeObject<List<Car>>(json);

                _db = new DBModel();
                _db.Cars.AddRange(cars);
            }
            else
            {
                throw new Exception("Json file does not exist!");
            }
        }

        public IQueryable<Car> All
        {
            get
            {
                return _db.Cars.AsQueryable<Car>();
            }
        }

        public IQueryable<Car> GetAllSoldCar()
        {
            return All.Where(c => c.IsSold);
        }

        public void Delete(Car item)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Car item)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        #region IDisposable

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //_context.Dispose(); when we use db connection
                }
                disposedValue = true;
            }
        }

        //~CarRepository()
        //{
        //    Dispose(false);
        //}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}