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

    // Start is called before the first frame update
    void Start()
    {
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
    }
}
