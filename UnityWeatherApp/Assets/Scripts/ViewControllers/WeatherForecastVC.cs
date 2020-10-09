using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherForecastVC : MonoBehaviour
{
    [SerializeField] WeatherForecastViewModel weatherForecastVM;
    [SerializeField] DailyForecastCell dailyForecastCellPrefab;
    [SerializeField] Transform tableView;

    void Start()
    {
        weatherForecastVM.GetData();
    }

    private void OnEnable()
    {
        weatherForecastVM.OnWeatherForecastDataFetched += OnWeatherForecastDataFetched;
    }

    private void OnDisable()
    {
        weatherForecastVM.OnWeatherForecastDataFetched -= OnWeatherForecastDataFetched;
    }

    private void OnWeatherForecastDataFetched()
    {
        foreach (DailyForecastCellVM dailyForecastCellVM in weatherForecastVM.DailyForecastList)
        {
            var dailyForecastGo = Instantiate(dailyForecastCellPrefab.gameObject);
            var dailyForecastCell = dailyForecastGo.GetComponent<DailyForecastCell>();
            dailyForecastCell.DailyForecastCellVM = dailyForecastCellVM;
            dailyForecastGo.transform.SetParent(tableView);
            dailyForecastGo.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
