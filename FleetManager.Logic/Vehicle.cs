using System;

namespace FleetManager.Logic;

public abstract class Vehicle
{
    #region fields
    private double _baseWeight = 0;
    private string _vehicleID;
    #endregion fields
    #region properties
    public double BaseWeight
    {
        get
        {
            return _baseWeight;
        }
    }
    public string VehicleID
    {
        get
        {
            return _vehicleID;
        }
    }
    #endregion properties
    #region constructor
    public Vehicle(string vehicleID, double baseWeight)
    {
        if (CheckId(vehicleID))
        {
            _vehicleID = vehicleID;
        }
        else
        {
            _vehicleID = "0000000000";
        }
        _baseWeight = baseWeight;
    }
    #endregion constructor
    #region helpMethods
    /// <summary>
    /// method, that will check the string id on given parameters return result
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static bool CheckId(string id)
    {
        bool result = false;
        if (id != null)
        {

            if (id.Length == 10)
            {
                char[] chars = id.ToCharArray();
                int sum = 0;
                for (int i = 0; i < chars.Length - 1; i++)
                {
                    sum += ((int)chars[i] - 48) * (i + 1);
                }
                int tmp = sum % 11;
                if (tmp == (int)chars[9] - 48)
                {
                    result = true;
                }
                else if (tmp == 10)
                {
                    result = id.EndsWith('X') ? true : false;
                }
            }
        }

        return result;
    }
    #endregion helpMethods
    #region abstract methods
    /// <summary>
    /// abstract method for Revenue
    /// </summary>
    /// <returns></returns>
    public abstract double GetRevenue();
    /// <summary>
    /// abstract method for Total Weight
    /// </summary>
    /// <returns></returns>
    public abstract double GetTotalWeight();
    #endregion abstract methods
}
