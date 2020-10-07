using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class FetchWeatherService : MonoBehaviour
{
    // Constants
    private const string BASE_URL = "https://api.openweathermap.org/data/2.5/";
    private const string API_KEY = "570aef4778feaeaaf782b6fefa9ae4b0";

    void Start()
    {
        //FetchCurrentWeatherData("Surrey");
        FetchWeatherForecastData("Vancouver");
    }

    public void FetchCurrentWeatherData(string cityName)
    {
        StartCoroutine(ProcessFetchCurrentWeatherRequest(cityName));
    }

    public void FetchWeatherForecastData(string cityName)
    {
        StartCoroutine(ProcessFetchForecastWeatherRequest(cityName));
    }

    private IEnumerator ProcessFetchCurrentWeatherRequest(string cityName)
    {
        var url = $"{BASE_URL}weather?q={cityName}&appid={API_KEY}";
        var request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            var currentWeather = WeatherModel.CreateFromJSON(request.downloadHandler.text);
            Debug.Log($"current weather ==== {currentWeather.weather[0].description}, {currentWeather.sys.country}");
        }
    }

    private IEnumerator ProcessFetchForecastWeatherRequest(string cityName)
    {
        var url = $"{BASE_URL}forecast?q={cityName}&appid={API_KEY}";
        var request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();
        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            var weatherForecast = WeatherForecastModel.CreateFromJSON(request.downloadHandler.text);
            Debug.Log($"current weather ==== {weatherForecast.message}, {weatherForecast.city.name}");

            foreach (var item in weatherForecast.list)
            {
                Debug.Log($"{item.dt_txt} : {item.name} {item.weather[0].description} {item.main.temp}");
            }
        }
    }
}
