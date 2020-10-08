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

    public void FetchCurrentWeatherData(double latitude, double longitude, Action<WeatherModel> requestHandler)
    {
        StartCoroutine(ProcessFetchCurrentWeatherRequest(latitude, longitude, requestHandler));
    }

    public void FetchWeatherForecastData(double latitude, double longitude, Action<WeatherForecastModel> requestHandler)
    {
        StartCoroutine(ProcessWeatherForecastRequest(latitude, longitude, requestHandler));
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

    private IEnumerator ProcessWeatherForecastRequest(double latitude, double longitude, Action<WeatherForecastModel> requestHandler)
    {
        var url = $"{BASE_URL}forecast?lat={latitude}&lon={longitude}&units={UNIT}&appid={API_KEY}";
        var request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();
        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            var weatherForecast = WeatherForecastModel.CreateFromJSON(request.downloadHandler.text);
            requestHandler(weatherForecast);
        }
    }
}
