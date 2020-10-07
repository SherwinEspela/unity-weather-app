using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class FetchWeatherService : MonoBehaviour
{
    // Constants
    private const string BASE_URL = "https://api.openweathermap.org/data/2.5/";
    private const string API_KEY = "570aef4778feaeaaf782b6fefa9ae4b0"; // "b1085d332366b974aff32c0294e1aef6"; 

    void Start()
    {
        FetchData("Surrey");
    }

    public void FetchData(string cityName)
    {
        StartCoroutine(ProcessRequest(cityName));
    }

    private IEnumerator ProcessRequest(string cityName)
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
            Debug.Log(request.downloadHandler.text);
        }

        var urlForecast = $"{BASE_URL}forecast?q={cityName}&appid={API_KEY}";
        var requestForecast = UnityWebRequest.Get(urlForecast);

        yield return requestForecast.SendWebRequest();
        if (requestForecast.isNetworkError)
        {
            Debug.Log(requestForecast.error);
        }
        else
        {
            Debug.Log(requestForecast.downloadHandler.text);
        }
    }
}
