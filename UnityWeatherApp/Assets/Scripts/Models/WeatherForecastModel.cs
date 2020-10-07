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

[Serializable]
public struct CityDataModel
{
    public int id;
    public string name;
    public string country;
}
                          

