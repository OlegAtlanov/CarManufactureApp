namespace CarManufactureApp.Models
{
    using FakeDBSet;
    using System.Data.Entity;

    public class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
            Cars = new CarDBSet<Car>();
        }

        public virtual DbSet<Car> Cars { get; set; }
    }
}