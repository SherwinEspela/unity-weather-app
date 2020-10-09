using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    [SerializeField] CurrentWeatherVC currentWeatherVC;
    [SerializeField] WeatherForecastVC weatherForecastVC;

    // Constants
    private const string TRIGGER_FADEIN = "TriggerFadeIn";
    private const string TRIGGER_FADEOUT = "TriggerFadeOut";

    // Cache
    private Animator animatorCurrentWeatherScreen;
    private Animator animatorWeatherForecastScreen;

    private void Start()
    {
        animatorCurrentWeatherScreen = currentWeatherVC.GetComponent<Animator>();
        animatorWeatherForecastScreen = weatherForecastVC.GetComponent<Animator>();

        DisplayCurrentWeatherScreen();
    }

    public void DisplayWeatherForecastScreen()
    {
        animatorCurrentWeatherScreen.SetTrigger(TRIGGER_FADEOUT);
        animatorWeatherForecastScreen.SetTrigger(TRIGGER_FADEIN);
    }

    public void DisplayCurrentWeatherScreen()
    {
        animatorWeatherForecastScreen.SetTrigger(TRIGGER_FADEOUT);
        animatorCurrentWeatherScreen.SetTrigger(TRIGGER_FADEIN);
    }
}
