using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ForceRefreshRate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (ExampleUtil.isPresent())
        {
            Time.fixedDeltaTime = (Time.timeScale / XRDevice.refreshRate);
        }
        else
        {
            Time.fixedDeltaTime = Time.timeScale / 60.0f;
        }
    }
}

internal static class ExampleUtil
{
    public static bool isPresent()
    {
        var xrDisplaySubsystems = new List<XRDisplaySubsystem>();
        SubsystemManager.GetInstances<XRDisplaySubsystem>(xrDisplaySubsystems);
        foreach (var xrDisplay in xrDisplaySubsystems)
        {
            if (xrDisplay.running)
            {
                return true;
            }
        }
        return false;
    }
}