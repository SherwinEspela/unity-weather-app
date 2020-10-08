using UnityEngine;
using System;

public class CurrentWeatherViewModel : MonoBehaviour
{
    [SerializeField] FetchWeatherService weatherService;
    [SerializeField] FetchLocationService locationService;

    // Properties
    public string City { get; set; }
    public string Description { get; set; }
    public string Temperature { get; set; }

    // Events
    public event Action OnCurrentWeatherDataFetched;

    public void GetData()
    {
        var coordinates = locationService.GetCoordinates();
        weatherService.FetchCurrentWeatherData(coordinates.Latitude, coordinates.Longitude, (weatherData) => {
            this.City = weatherData.name;
            this.Description = weatherData.weather[0].description;
            this.Temperature = $"{weatherData.main.temp.ToString()}°C";
            OnCurrentWeatherDataFetched();
        });
    }
}
