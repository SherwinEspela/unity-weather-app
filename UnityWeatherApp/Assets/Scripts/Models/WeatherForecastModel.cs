using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class WeatherForecastModel
{
    public string cod;
    public string message;
    public WeatherModel[] list;
    public CityDataModel city;

    public static WeatherForecastModel CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<WeatherForecastModel>(jsonString);
    }
}

//[Serializable]
//public struct DailyForecastModel
//{
//    public int dt;
//    public string sunrise;
//    public string sunset;
//    public TemperatureModel temp;
//}

//[Serializable]
//public struct TemperatureModel
//{
//    public double day;
//    public double min;
//    public double max;
//    public double night;
//    public double eve;
//    public double morn;
//}

[Serializable]
public struct CityDataModel
{
    public int id;
    public string name;
    public string country;
}
                          

