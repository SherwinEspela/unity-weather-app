﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DailyForecastCell : MonoBehaviour
{
    private DailyForecastCellVM dailyForecastVM;

    // Property
    public DailyForecastCellVM DailyForecastCellVM
    {
        set
        {
            dailyForecastVM = value;
            textDay.text = dailyForecastVM.Day;
            textTime.text = dailyForecastVM.Time;
            textDescription.text = dailyForecastVM.Description;
            textTemperature.text = dailyForecastVM.Temperature;
            textTempMin.text = dailyForecastVM.TemperatureMin;
            textTempMax.text = dailyForecastVM.TemperatureMax;
            textPressure.text = dailyForecastVM.Pressure;
            textHumidity.text = dailyForecastVM.Humidity;

            var service = FindObjectOfType<FetchWeatherService>();
            service.FetchWeatherIcon(dailyForecastVM.IconType, (iconSprite) =>
            {
                imageIcon.sprite = iconSprite;
                imageIcon.gameObject.SetActive(true);
            });
        }
    }

    // UI Elements
    [SerializeField] TextMeshProUGUI textDay;
    [SerializeField] TextMeshProUGUI textTime;
    [SerializeField] TextMeshProUGUI textDescription;
    [SerializeField] TextMeshProUGUI textTemperature;
    [SerializeField] TextMeshProUGUI textTempMin;
    [SerializeField] TextMeshProUGUI textTempMax;
    [SerializeField] TextMeshProUGUI textPressure;
    [SerializeField] TextMeshProUGUI textHumidity;
    [SerializeField] Image imageIcon;
}
