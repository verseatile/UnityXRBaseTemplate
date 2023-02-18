using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBlaster : MonoBehaviour
{
    public GameObject AmmoObject;
    public float launchVelocity = 700f;
    private bool triggerValue;
    private UnityEngine.XR.InputDevice rightControllerDevice;

    private void fireProjectile()
    {
        GameObject projectile = Instantiate(AmmoObject, transform.position,
                                                             transform.rotation);
        projectile.GetComponent<Rigidbody>().AddRelativeForce( new Vector3( 0, 0, launchVelocity ) );
    }

    // Start is called before the first frame update
    void Start()
    {
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);

        if(rightHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice device = rightHandDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.characteristics.ToString()));
            rightControllerDevice = rightHandDevices[0];
        }
        else if(rightHandDevices.Count > 1)
        {
            Debug.Log("Found more than one right hand!");
        }

        if (AmmoObject)
        {
            Debug.Log(AmmoObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rightControllerDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            Debug.Log("Trigger button is pressed.");
            fireProjectile();
        }
    }
}
