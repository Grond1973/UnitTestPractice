using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleCommon;

namespace VehicleDAL
{
    public interface IVehicleDAL
    {
        IEnumerable<Vehicle> GetVehicleCollectionByUserId(int userId);

        Vehicle GetVehicleByUserIdVehicleId(int userId, int vehicleId);
    }
}
