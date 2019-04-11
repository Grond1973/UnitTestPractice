using System;
/**
 *
 *	@author: Lawrence F. Sullivan
 *
 *	@date:	12-27-18
 *
 *	@purpose: Vehicle class
 * 
 * 
 *	@modifications: 
 *	                
 *
 *	@notes:
 *
 *
 */
namespace VehicleCommon
{
    public class Vehicle
    {
        #region [ CLASS FIELDS ]

        private int _userId;
        private int _vehicleId;
        private string _model;
        private string _make;
        private bool _isActive;
        
        #endregion

        #region [ CONSTRUCTOR ]

        public Vehicle()
        {
            this._userId = 0;
            this._vehicleId = 0;
            this._model = String.Empty;
            this._make = String.Empty;
            this._isActive = false;
        }

        public Vehicle(int userId, int vehicleId, string model, string make, bool isActive)
        {
            this._userId = userId;
            this._vehicleId = vehicleId;
            this._model = model;
            this._make = make;
            this._isActive = isActive;
        }

        #endregion

        #region [ PROPERTIES ]
        public int UserId { get => _userId; set => _userId = value; }
        public int Id { get => _vehicleId; set => _vehicleId = value; }
        public string Model { get => _model; set => _model = value; }
        public string Make { get => _make; set => _make = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }

        #endregion

        #region [ METHODS ]

        #endregion
    }
}
