using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class DailyForecastCellVM : MonoBehaviour
{
    // Properties
    public string Day { get; set; }
    public string Time { get; set; }
    public string MainDescription { get; set; }
    public string Description { get; set; }
    public string Temperature { get; set; }
    public string TemperatureMin { get; set; }
    public string TemperatureMax { get; set; }
    public string Pressure { get; set; }
    public string Humidity { get; set; }
    //public Texture2D TextureIcon { get; set; }
    public string IconType { get; set; }

    public void GetIconTexture(Action<Texture2D> requestHandler)
    {
        Debug.Log("get icon texture called...");
        StartCoroutine(DownloadIconImage(requestHandler));
    }

    private IEnumerator DownloadIconImage(Action<Texture2D> requestHandler)
    {
        var url = $"http://openweathermap.org/img/wn/10d@2x.png";
        var request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            requestHandler(texture);
        }
    }
}
