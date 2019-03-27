using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScript : MonoBehaviour
{
	void Start () {
        if(Display.displays.Length > 1)
            Display.displays[1].Activate();
        Debug.Log("displays connected: " + Display.displays.Length);
    }
}
