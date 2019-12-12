using MV.Prometric.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MV.Prometric.IDomainServices
{
    public interface IVehicleService
    {
        List<VehicleViewModel> GetAll();
        VehicleViewModel Save(VehicleViewModel viewModel);
    }
}
