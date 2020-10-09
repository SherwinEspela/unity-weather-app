using System.Collections;
using UnityEngine;
using System;

public class FetchLocationService : MonoBehaviour
{
    // Coordinates from a Vancouver location to test in Editor
    private const float TEST_LATITUDE = -123.1189449f;
    private const float TEST_LONGITUDE = 49.284244f;

    public CoordinatesModel GetTestCoordinates()
    {
        var coordinates = new CoordinatesModel() { lat = TEST_LATITUDE, lon = TEST_LONGITUDE };
        return coordinates;
    }

    public void GetCurrentUserLocation(Action<CoordinatesModel> onCoordinateRetrievedhandler)
    {
        StartCoroutine(ProcessGetCurrentUserLocation(onCoordinateRetrievedhandler));
    }

    private IEnumerator ProcessGetCurrentUserLocation(Action<CoordinatesModel> onCoordinateRetrievedhandler)
    {
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            // Timed out
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            // Unable to determine device location
            yield break;
        }

        // Access granted and location value could be retrieved
        onCoordinateRetrievedhandler(new CoordinatesModel()
        {
            lat = Input.location.lastData.latitude,
            lon = Input.location.lastData.longitude
        });

        // Stop service if there is no need to
        // query location updates continuously
        Input.location.Stop();
    }
}

