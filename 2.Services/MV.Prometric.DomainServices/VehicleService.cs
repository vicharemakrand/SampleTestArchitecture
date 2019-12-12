using MV.Prometric.EntityModels;
using MV.Prometric.IDomainServices;
using MV.Prometric.IRepositories;
using MV.Prometric.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MV.Prometric.DomainServices
{
    public class VehicleService: IVehicleService
    {
        private readonly IVehicleReposistory _vehicleReposistory;
        public VehicleService(IVehicleReposistory vehicleReposistory)
        {
            _vehicleReposistory = vehicleReposistory;
        }
        public virtual List<VehicleViewModel> GetAll()
        {
                var entities = _vehicleReposistory.GetAll();
                return entities.Select(o => new VehicleViewModel { ModelName = o.ModelName }).ToList();
        }

        public virtual VehicleViewModel Save(VehicleViewModel viewModel)
        {
            var entity = new Vehicle {
                Id = viewModel.Id,
                ModelName = viewModel.ModelName,
                Color = viewModel.Color,
                MpgValue = viewModel.MpgValue
                };

                if (viewModel.Id == 0)
                {
                    _vehicleReposistory.Insert(entity);
                    viewModel.Id = entity.Id;
                }
                else
                {
                    throw new NotImplementedException();
                }

                return viewModel;
        }
    }
}
