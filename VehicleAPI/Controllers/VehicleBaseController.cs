using log4net;
using System.Web.Http;
using VehicleDAL;
/**
*
*	@author: Lawrence F. Sullivan
*
*	@date:	12-27-18
*
*	@purpose: Vehicle controller abstract base class
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
    public abstract class VehicleBaseController : ApiController
    {
        #region [ CLASS FIELDS ]

        protected ILog _logger;
        protected IVehicleDAL _dataAccessLayer;

        #endregion

        #region [ CONSTRUCTOR ]

        public VehicleBaseController(ILog logger, IVehicleDAL vehicleDAL)
        {
            this._logger = logger;
            this._dataAccessLayer = vehicleDAL;
        }
        #endregion

        #region [ PROPERTIES ]

        #endregion

        #region [ METHODS ]

        #endregion
    }
}
