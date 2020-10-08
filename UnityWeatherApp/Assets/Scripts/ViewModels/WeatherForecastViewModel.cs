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
                    Temperature = item.main.temp.ToString(),
                    TemperatureMin = item.main.temp_min.ToString(),
                    TemperatureMax = item.main.temp_max.ToString(),
                    Pressure = item.main.pressure.ToString(),
                    Humidity = item.main.humidity.ToString()
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

    //{"dt":1602568800,"main":{"temp":8.1,"feels_like":5.94,"temp_min":8.1,"temp_max":8.1,"pressure":1019,"sea_level":1019,"grnd_level":1012,"humidity":85,"temp_kf":0},"weather":[{"id":803,"main":"Clouds","description":"broken clouds","icon":"04n"}],"clouds":{"all":73},"wind":{"speed":1.7,"deg":83},"visibility":10000,"pop":0.05,"sys":{"pod":"n"},"dt_txt":"2020-10-13 06:00:00"}
}
