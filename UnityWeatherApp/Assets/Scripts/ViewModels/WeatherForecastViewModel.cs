using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeatherForecastViewModel : MonoBehaviour
{
    [SerializeField] FetchWeatherService weatherService;
    [SerializeField] FetchLocationService locationService;

    // Properties
    public List<DailyForecastCellVM> DailyForecastList { get; set; }

    // Events
    public event Action OnWeatherForecastDataFetched;

    public void GetData()
    {
        var coordinates = locationService.GetCoordinates();
  
        weatherService.FetchWeatherForecastData(coordinates.Latitude, coordinates.Longitude, (forecastData) => {
            this.DailyForecastList = new List<DailyForecastCellVM>();

            var weatherModels = forecastData.list;
            foreach (WeatherModel item in weatherModels)
            {
                var dailyForecastCellVM = new DailyForecastCellVM() {
                    Day = GetDayOfWeek(item.dt_txt),
                    Time = GetDateAndTime(item.dt_txt),
                    Description = item.weather[0].description,
                    Temperature = $"{Mathf.FloorToInt(item.main.temp)}°C",
                    TemperatureMin = $"{Mathf.FloorToInt(item.main.temp_min)}°C",
                    TemperatureMax = $"{Mathf.FloorToInt(item.main.temp_max)}°C",
                    Pressure = item.main.pressure.ToString(),
                    Humidity = item.main.humidity.ToString(),
                    IconType = item.weather[0].icon
                };

                this.DailyForecastList.Add(dailyForecastCellVM);
            }

            OnWeatherForecastDataFetched();
        });
    }

    private string GetDayOfWeek(string dateString)
    {
        DateTime date = DateTime.Parse(dateString,
                          System.Globalization.CultureInfo.InvariantCulture);
        return date.DayOfWeek.ToString();
    }

    private string GetDateAndTime(string dateString)
    {
        DateTime date = DateTime.Parse(dateString,
                          System.Globalization.CultureInfo.InvariantCulture);
        return $"{date.Month}/{date.Day} {date.ToShortTimeString()}";
    }
}
