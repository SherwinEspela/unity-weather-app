using System.Collections;
using UnityEngine;
using System;

public class FetchLocationService : MonoBehaviour
{
    public CoordinatesModel GetTestCoordinates()
    {
        // Coordinates from a Vancouver location to test in Editor
        var coordinates = new CoordinatesModel() { lat = -122.685091f, lon = 49.124663f };
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

