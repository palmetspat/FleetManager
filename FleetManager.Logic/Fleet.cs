using System;
using System.Text;

namespace FleetManager.Logic;

public class Fleet
{
    #region fields
    List<Vehicle> _vehicleList = new();
    #endregion fields
    #region properties
    public IReadOnlyList<Vehicle> Vehicles
    {
        get
        {
            return _vehicleList;
        }
    }

    public int MaxFleetWeight { get; }
    public int PassengerVehicleCount
    {
        get
        {
            return GetTotalPassengerCount();
        }
    }
    #endregion properties
    #region constructor
    public Fleet(int maxFleetWeight)
    {
        MaxFleetWeight = maxFleetWeight;
    }
    #endregion constructor
    #region methods
    /// <summary>
    /// method that calculate the flee weight
    /// </summary>
    /// <returns></returns>
    public double GetFleetWeight()
    {
        double result = 0;
        foreach (Vehicle vehicle in Vehicles)
        {
            result += vehicle.GetTotalWeight();
        }
        return result;
    }
    /// <summary>
    /// method that calculate the most profitable vehicle
    /// </summary>
    /// <returns></returns>
    public Vehicle GetMostProfitableVehicle()
    {
        Vehicle result = null!;
        if (_vehicleList != null)
        {
            _vehicleList.Sort((b, a) => a.GetRevenue().CompareTo(b.GetRevenue()));
            result = _vehicleList[0];
        }
        return result!;
    }
    /// <summary>
    /// method that count the total passengers
    /// </summary>
    /// <returns></returns>
    public int GetTotalPassengerCount()
    {
        int result = 0;
        foreach (PassengerVehicle vehicle in Vehicles)
        {
            result += vehicle.PassengerCount;
        }
        return result;
    }
    /// <summary>
    /// method that add a vehicle by Given newVehicle
    /// </summary>
    /// <returns></returns>
    public bool AddVehicle(Vehicle newVehicle)
    {
        bool result = false;
        if (GetFleetWeight() + newVehicle.GetTotalWeight() <= MaxFleetWeight)
        {
            _vehicleList.Add(newVehicle);
            _vehicleList.Sort((b, a) => a.GetTotalWeight().CompareTo(b.GetTotalWeight()));
            result = true;
        }
        return result;
    }
    /// <summary>
    /// method that adds passenger by Given vehicleID and additionalPassengers
    /// </summary>
    /// <returns></returns>
    public bool AddPassengersToVehicle(string vehicleID, int additionalPassengers)
    {
        PassengerVehicle? tmp = null;
        bool result = false;
        foreach (PassengerVehicle vehicle in Vehicles)
        {
            if (vehicle.VehicleID == vehicleID)
            {
                tmp = vehicle;
            }
        }
        if (tmp != null && tmp!.PassengerCount + additionalPassengers <= 50)
        {
            tmp.PassengerCount += additionalPassengers;
            result = true;
        }
        return result;
    }/// <summary>
     /// The method sorts a list of vehicles in ascending order based on their revenue 
     /// </summary>
     /// <returns></returns>
    public IReadOnlyList<Vehicle> GetByRevenue()
    {
        List<Vehicle> result = _vehicleList;
        result.Sort((a, b) => a.GetRevenue().CompareTo(b.GetRevenue()));
        return result;
    }
    #endregion methods
    #region override methods
    /// <summary>
    /// StringBuilder that outputs the VehicleID, TotalWeight and Revenue values ​​for fleet
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Vehicle vehicle in _vehicleList)
        {
            sb.Append("VehicleID: " + vehicle.VehicleID + " TotalWeight: " + vehicle.GetTotalWeight() + " Revenue: " + vehicle.GetRevenue());
            sb.AppendLine();
        }
        return sb.ToString();
    }
    #endregion override methods
}
