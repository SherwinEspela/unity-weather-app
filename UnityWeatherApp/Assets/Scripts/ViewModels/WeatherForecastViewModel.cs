using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherForecastViewModel : MonoBehaviour
{
    [SerializeField] FetchWeatherService weatherService;
    [SerializeField] FetchLocationService locationService;

    // Properties
    public WeatherForecastModel[] forecastList;
    public string Day { get; set; }
    public string MainDescription { get; set; }
    public string Description { get; set; }
    public string Temperature { get; set; }
    public string TemperatureMin { get; set; }
    public string TemperatureMax { get; set; }
    public string Pressure { get; set; }
    public string Humidity { get; set; }
}
