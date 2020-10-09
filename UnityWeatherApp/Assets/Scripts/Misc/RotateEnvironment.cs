using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnvironment : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1.0f;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}
