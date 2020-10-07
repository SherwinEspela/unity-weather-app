﻿using UnityEngine;
using System;

[Serializable]
public class WeatherModel
{
    public WeatherDataModel[] weather;
    public MainDataModel main;
    public SysDataModel sys;

    public int id;
    public string name;
    public int cod;
    public string dt_txt;

    public static WeatherModel CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<WeatherModel>(jsonString);
    }
}

[Serializable]
public struct WeatherDataModel
{
    public int id;
    public string main;
    public string description;
    public string icon;
}

[Serializable]
public struct MainDataModel
{
    public float temp;
    public int pressure;
    public int humidity;
    public float temp_min;
    public float temp_max;
}

[Serializable]
public struct SysDataModel
{
    public int type;
    public int id;
    public float message;
    public string country;
    public int sunrise;
    public int sunset;
}