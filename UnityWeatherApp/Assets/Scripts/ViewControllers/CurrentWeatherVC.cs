using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWeatherVC : MonoBehaviour
{
    [SerializeField] CurrentWeatherViewModel currentWeatherVM;
    [SerializeField] Text textCity;
    [SerializeField] Text textDescription;
    [SerializeField] Text textTemperature;
    [SerializeField] Image imageIcon;
    [SerializeField] Text textPressure;
    [SerializeField] Text textHumidity;
    [SerializeField] Text textLatitude;
    [SerializeField] Text textLongitude;
    [SerializeField] Text textTempMin;
    [SerializeField] Text textTempMax;
    [SerializeField] Text textWindSpeed;
    [SerializeField] Text textWindDegree;
    [SerializeField] Text textCountry;

    void Start()
    {
        imageIcon.gameObject.SetActive(false);
        currentWeatherVM.GetData();
    }

    private void OnEnable()
    {
        currentWeatherVM.OnCurrentWeatherDataFetched += OnCurrentWeatherDataFetched;
    }

    private void OnDisable()
    {
        currentWeatherVM.OnCurrentWeatherDataFetched -= OnCurrentWeatherDataFetched;
    }

    private void OnCurrentWeatherDataFetched()
    {
        textCity.text = currentWeatherVM.City;
        textDescription.text = currentWeatherVM.Description;
        textTemperature.text = currentWeatherVM.Temperature;

        textPressure.text = $"Pressure: {currentWeatherVM.Pressure}";
        textHumidity.text = $"Humidity: {currentWeatherVM.Humidity}";
        textLatitude.text = $"Latitude: {currentWeatherVM.Latitude}";
        textLongitude.text = $"Longitude: {currentWeatherVM.Longitude}";
        textTempMin.text = $"Temperature Min: {currentWeatherVM.TempMin}";
        textTempMax.text = $"Temperature Max: {currentWeatherVM.TempMax}";
        textWindSpeed.text = $"Wind Speed: {currentWeatherVM.WindSpeed}";
        textWindDegree.text = $"Wind Degree: {currentWeatherVM.WindDegree}";
        textCountry.text = $"Country: {currentWeatherVM.Country}";

        //current weather ====== { "coord":{ "lon":-122.69,"lat":49.12},"weather":[{"id":804,"main":"Clouds","description":"overcast clouds","icon":"04n"}],"base":"stations","main":{"temp":13.81,"feels_like":13.14,"temp_min":12.78,"temp_max":14.44,"pressure":1008,"humidity":82},"visibility":10000,"wind":{"speed":1.33,"deg":128},"clouds":{"all":86},"dt":1602218504,"sys":{"type":3,"id":2008532,"country":"CA","sunrise":1602166896,"sunset":1602207260},"timezone":-25200,"id":5924204,"name":"Cloverdale","cod":200}

        var service = FindObjectOfType<FetchWeatherService>();
        service.FetchWeatherIcon(currentWeatherVM.IconType, (iconSprite) =>
        {
            imageIcon.sprite = iconSprite;
            imageIcon.gameObject.SetActive(true);
        });
    }
}
