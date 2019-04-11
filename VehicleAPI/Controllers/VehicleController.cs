using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VehicleCommon;
using VehicleDAL;
/**
*
*	@author: Lawrence F. Sullivan
*
*	@date:	12-27-18
*
*	@purpose: Vehicle controller class
* 
* 
*	@modifications: 
*	                
*
*	@notes:
*
*
*/
namespace VehicleAPI.Controllers
{
    [RoutePrefix("api/vehicle")]
    public class VehicleController : VehicleBaseController
    {
        #region [ CLASS FIELDS ]

        #endregion

        #region [ CONSTRUCTOR ]

        public VehicleController(ILog logger, IVehicleDAL vehicleDAL) : base(logger, vehicleDAL)
        { this._logger.Info("In VehicleController ctor()..."); }
        #endregion

        #region [ PROPERTIES ]

        #endregion

        #region [ METHODS ]

        [Route("{userId}")]
        [HttpGet]
        public IEnumerable<Vehicle> Get(int userid)
        {
            this._logger.Debug("In method Get(int id)...");
            return this._dataAccessLayer.GetVehicleCollectionByUserId(userid);
        }

        [Route("{userId}/{vehicleId}")]
        [HttpGet]
        public Vehicle Get(int userId, int vehicleId)
        {
            this._logger.Debug("In method Get(int userid, int vehicleId)...");
            return this._dataAccessLayer.GetVehicleByUserIdVehicleId(userId, vehicleId);
        }

        public HttpResponseMessage Post(Vehicle vehicle)
        {
            this._logger.Info("In Post() Method...");
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
        #endregion
    }
}
