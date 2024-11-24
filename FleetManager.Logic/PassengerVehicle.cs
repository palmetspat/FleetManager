using System;
using System.Text;

namespace FleetManager.Logic;

public class PassengerVehicle : Vehicle
{
    #region fields
    private int _passengerCount = 0;
    private double _ticketPrice = 0;

    #region properties
    public int PassengerCount
    {
        get
        {
            return _passengerCount;
        }
        set
        {
            _passengerCount = value;
        }
    }
    #endregion fields
    #endregion properties
    #region constructors
    public PassengerVehicle(string vehicleID, double baseWeight, int passengerCount, double ticketPrice)
        : base(vehicleID, baseWeight)
    {
        if (passengerCount <= 50)
        {
            _passengerCount = passengerCount;
        }
        else
        {
            _passengerCount = 50;
        }
        _ticketPrice = ticketPrice;
    }
    
    public PassengerVehicle(string vehicleID, double baseWeight, double ticketPrice)
        : base(vehicleID, baseWeight)
    {
        _passengerCount = 20;
        _ticketPrice = ticketPrice;
    }
    #endregion constructors
    #region override methods
    /// <summary>
    ///  return calulation of revenue by passenger
    /// </summary>
    /// <returns></returns>
    public override double GetRevenue()
    {
        return PassengerCount * _ticketPrice;
    }
    /// <summary>
    ///  return calulation of total weight for passenger
    /// </summary>
    /// <returns></returns>
    public override double GetTotalWeight()
    {
        return BaseWeight + (PassengerCount * 70);
    }
    /// <summary>
    /// StringBuilder that outputs the VehicleID, TotalWeight and Revenue values ​​for passenger
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        StringBuilder outputString = new StringBuilder();
        outputString.Append("VehicleID: " + VehicleID + " TotalWeight: " + GetTotalWeight() + " Revenue: " + GetRevenue());
        return outputString.ToString();
    }
    #endregion override methods
}
