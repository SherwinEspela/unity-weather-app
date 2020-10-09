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
        //currentWeatherVC.gameObject.SetActive(false);
        //weatherForecastVC.gameObject.SetActive(true);

        animatorCurrentWeatherScreen.SetTrigger(TRIGGER_FADEOUT);
        animatorWeatherForecastScreen.SetTrigger(TRIGGER_FADEIN);
    }

    public void DisplayCurrentWeatherScreen()
    {
        //currentWeatherVC.gameObject.SetActive(true);
        //weatherForecastVC.gameObject.SetActive(false);
        animatorWeatherForecastScreen.SetTrigger(TRIGGER_FADEOUT);
        animatorCurrentWeatherScreen.SetTrigger(TRIGGER_FADEIN);
    }
}
