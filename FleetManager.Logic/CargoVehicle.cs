using System;
using System.Text;

namespace FleetManager.Logic;

public class CargoVehicle : Vehicle
{
    #region fields
    private double _cargoWeight = 0;
    private double _ratePerTon = 0;
    #endregion fields
    #region properties
    public double CargoWeight
    {
        get
        {
            return _cargoWeight;
        }
        set
        {
            _cargoWeight = value;
        }
    }
    #endregion properties
    #region constructor
    public CargoVehicle(string vehicleID, double baseWeight, double cargoWeight, double ratePerTon)
        : base(vehicleID, baseWeight)
    {
        if (cargoWeight <= 20)
        {
            _cargoWeight = cargoWeight;
        }
        else
        {
            _cargoWeight = 20;
        }
        _ratePerTon = ratePerTon;
    }
    #endregion constructor
    #region override methods
    /// <summary>
    ///  return calulation of revenue by passenger
    /// </summary>
    /// <returns></returns>
    public override double GetRevenue()
    {
        return CargoWeight * _ratePerTon;
    }
    /// <summary>
    ///  return calulation of total weight for cargo weight
    /// </summary>
    /// <returns></returns> 
    public override double GetTotalWeight()
    {
        return BaseWeight + (CargoWeight * 1000);
    }
    /// <summary>
    /// StringBuilder that outputs the VehicleID, TotalWeight and Revenue values ​​for cargo vehicle
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("VehicleID: " + VehicleID + " TotalWeight: " + GetTotalWeight() + " Revenue: " + GetRevenue());
        return sb.ToString();
    }
    #endregion override methods
}
