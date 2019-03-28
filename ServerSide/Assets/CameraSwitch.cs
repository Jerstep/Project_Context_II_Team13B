using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera[] cams;
    public float waitBeforeSwitch;

    public void ActivateSwitchCam()
    {
        StartCoroutine(WaitBeforeSwitchCam(cams[0], cams[1]));
    }

    IEnumerator WaitBeforeSwitchCam(Camera cam1, Camera cam2)
    {
        yield return new WaitForSeconds(waitBeforeSwitch);
        cam1.transform.position = cam2.transform.position;
        cam1.transform.rotation = cam2.transform.rotation;
    }
}
