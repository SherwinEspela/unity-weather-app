using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    [SerializeField] CurrentWeatherVC currentWeatherVC;
    [SerializeField] WeatherForecastVC weatherForecastVC;

    private void Start()
    {
        DisplayCurrentWeatherScreen();
    }

    public void DisplayWeatherForecastScreen()
    {
        currentWeatherVC.gameObject.SetActive(false);
        weatherForecastVC.gameObject.SetActive(true);
    }

    public void DisplayCurrentWeatherScreen()
    {
        currentWeatherVC.gameObject.SetActive(true);
        weatherForecastVC.gameObject.SetActive(false);
    }
}
