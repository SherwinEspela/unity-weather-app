using UnityEngine;
using System;

public class CurrentWeatherViewModel : MonoBehaviour
{
    [SerializeField] FetchWeatherService weatherService;
    [SerializeField] FetchLocationService locationService;

    // Properties
    public string City { get; set; }
    public string MainDescription { get; set; }
    public string Description { get; set; }
    public string Temperature { get; set; }
    public string IconType { get; set; }
    public string Pressure { get; set; }
    public string Humidity { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string TempMin { get; set; }
    public string TempMax { get; set; }
    public string WindSpeed { get; set; }
    public string WindDegree { get; set; }
    public string Country { get; set; }

    // Events
    public event Action OnCurrentWeatherDataFetched;

    public void GetData()
    {
#if UNITY_EDITOR
        // Unity Editor
        var coordinates = locationService.GetTestCoordinates();
        PerformDataFetching(coordinates);
#else
        // other platforms
        locationService.GetCurrentUserLocation((coords) =>
        {
            PerformDataFetching(coords);
        });
#endif
    }

    private void PerformDataFetching(CoordinatesModel coordinates)
    {
        weatherService.FetchCurrentWeatherData(coordinates.lon, coordinates.lat, (weatherData) => {
            var weather = weatherData.weather[0];
            this.City = weatherData.name;
            this.MainDescription = weather.main;
            this.Description = weather.description;
            this.IconType = weather.icon;
            this.Temperature = $"{Mathf.Floor(weatherData.main.temp)}°C";
            this.Pressure = weatherData.main.pressure.ToString();
            this.Humidity = weatherData.main.humidity.ToString();
            this.Latitude = weatherData.coord.lat.ToString();
            this.Longitude = weatherData.coord.lon.ToString();
            this.TempMin = $"{Mathf.Floor(weatherData.main.temp_min)}°C";
            this.TempMax = $"{Mathf.Floor(weatherData.main.temp_max)}°C";
            this.WindSpeed = weatherData.wind.speed.ToString();
            this.WindDegree = weatherData.wind.deg.ToString();
            this.Country = weatherData.sys.country;

            OnCurrentWeatherDataFetched();
        });
    }
}
