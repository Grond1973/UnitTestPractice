using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleCommon;
/**
*
*	@author: Lawrence F. Sullivan
*
*	@date:	12-27-18
*
*	@purpose: Data Access Layer for vehicles that takes its data source
*	            from JSON flat files.
* 
* 
*	@modifications: 
*	                
*
*	@notes:
*
*
*/
namespace VehicleDAL
{
    public class JsonPoweredDAL : IVehicleDAL
    {
        #region [ CLASS FIELDS ]

        private ILog _logger;
        private string _rawJsonVehicleData;
        private string _rawJsonUserData;

        #endregion

        #region [ CONSTRUCTOR ]

        public JsonPoweredDAL(string pathToUsersJsonFile, string pathToVehiclesJsonFile, ILog logger)
        {
            this._logger = logger;
            this._rawJsonVehicleData = String.Empty;
            this._rawJsonUserData = String.Empty;
            this._logger.Debug("In JsonPoweredDAL ctor()...");

            this._rawJsonVehicleData = this._loadRawJson(pathToVehiclesJsonFile);
            this._rawJsonUserData = this._loadRawJson(pathToUsersJsonFile);
        }
        #endregion

        #region [ PROPERTIES ]

        #endregion

        #region [ METHODS ]
        public IEnumerable<Vehicle> GetVehicleCollectionByUserId(int userId)
        {
            List<Vehicle> vehicles = null;

            var rawList = JsonConvert.DeserializeObject<List<Vehicle>>(this._rawJsonVehicleData);
            vehicles = rawList.Where(itm => itm.UserId == userId).ToList();
            return vehicles;
        }

        public Vehicle GetVehicleByUserIdVehicleId(int userId, int vehicleId)
        {
            Vehicle vehicle = null;
            var rawList = JsonConvert.DeserializeObject<List<Vehicle>>(this._rawJsonVehicleData);
            vehicle = rawList.Where(itm => itm.UserId == userId && itm.Id == vehicleId).FirstOrDefault();
            return vehicle;
        }

        private string _loadRawJson(string pathToDataFile)
        {
            string rawJson = String.Empty;

            try
            { rawJson = File.ReadAllText(pathToDataFile);}
            catch(Exception ex)
            {
                this._logger.Error(ex);
                throw;
            }
            return rawJson;
        }
        #endregion

    }
}
