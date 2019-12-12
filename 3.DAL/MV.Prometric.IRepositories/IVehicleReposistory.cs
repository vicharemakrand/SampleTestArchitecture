using MV.Prometric.EntityModels;
using System.Collections.Generic;

namespace MV.Prometric.IRepositories
{
    public interface IVehicleReposistory
    {
        IEnumerable<Vehicle> GetAll();

        Vehicle Insert(Vehicle vehicle);

        void DeleteAll();
        void Save();

    }
}
