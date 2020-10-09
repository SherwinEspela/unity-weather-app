using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    // Skybox Materials
    [SerializeField] Material materialClear;
    [SerializeField] Material materialClouds;
    [SerializeField] Material materialDrizzle;
    [SerializeField] Material materialRain;
    [SerializeField] Material materialSnow;
    [SerializeField] Material materialThunderstorm;

    [SerializeField] float scrollSpeed = 1.0f;

    public void SetBackground(string mainDescription)
    {
        RenderSettings.skybox = GetSkyboxMaterial(mainDescription);
    }

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * scrollSpeed);
    }

    private Material GetSkyboxMaterial(string mainDescription)
    {
        switch (mainDescription)
        {
            case Constants.WeatherConditions.CLEAR:
                return materialClear;

            case Constants.WeatherConditions.CLOUDS:
                return materialClouds;

            case Constants.WeatherConditions.DRIZZLE:
                return materialClouds;

            case Constants.WeatherConditions.RAIN:
                return materialClouds;

            case Constants.WeatherConditions.SNOW:
                return materialClouds;

            case Constants.WeatherConditions.THUNDERSTORM:
                return materialClouds;

            default:
                return materialClear;
        }
    }
}
