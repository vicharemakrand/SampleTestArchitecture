using MV.Prometric.EntityModels;
using MV.Prometric.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace MV.Prometric.Repositories
{
    public class VehicleRepository : IVehicleReposistory
    {
        private readonly TestDbEntities _context;
        public VehicleRepository(TestDbEntities context)
        {
            _context = context;
        }
        public virtual IEnumerable<Vehicle> GetAll()
        {
            return _context.Vehicles.ToList();
        }

        public virtual Vehicle Insert(Vehicle vehicle)
        {
            return _context.Vehicles.Add(vehicle);
        }

        public virtual void DeleteAll()
        {
            _context.Vehicles.ToList().ForEach(o => _context.Vehicles.Remove(o));
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }


    }
}
