using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class FetchWeatherService : MonoBehaviour
{
    // Constants
    private const string BASE_URL = "https://api.openweathermap.org/data/2.5/";
    private const string API_KEY = "570aef4778feaeaaf782b6fefa9ae4b0";
    private const string UNIT = "metric";

    public void FetchCurrentWeatherData(string cityName)
    {
        StartCoroutine(ProcessFetchCurrentWeatherRequest(cityName));
    }

    public void FetchCurrentWeatherData(double latitude, double longitude, Action<WeatherModel> requestHandler)
    {
        StartCoroutine(ProcessFetchCurrentWeatherRequest(latitude, longitude, requestHandler));
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

    private IEnumerator ProcessFetchCurrentWeatherRequest(double latitude, double longitude, Action<WeatherModel> requestHandler)
    {
        var url = $"{BASE_URL}weather?lat={latitude}&lon={longitude}&units={UNIT}&appid={API_KEY}";
        var request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            var currentWeather = WeatherModel.CreateFromJSON(request.downloadHandler.text);
            requestHandler(currentWeather);
        }
    }

    // TODO: Refactor
    //private IEnumerator ProcessRequest<T>(string url)
    //{
    //    var request = UnityWebRequest.Get(url);
    //    yield return request.SendWebRequest();

    //    if (request.isNetworkError)
    //    {
    //        Debug.Log(request.error);
    //    }
    //    else
    //    {
    //        var currentWeather = JsonUtility.FromJson<T>(request.downloadHandler.text);
    //    }
    //}

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
