using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWeatherVC : MonoBehaviour
{
    [SerializeField] CurrentWeatherViewModel currentWeatherVM;
    [SerializeField] EnvironmentManager environmentManager;
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
        environmentManager.SetBackground(currentWeatherVM.MainDescription);

        var service = FindObjectOfType<FetchWeatherService>();
        service.FetchWeatherIcon(currentWeatherVM.IconType, (iconSprite) =>
        {
            imageIcon.sprite = iconSprite;
            imageIcon.gameObject.SetActive(true);
        });
    }
}
