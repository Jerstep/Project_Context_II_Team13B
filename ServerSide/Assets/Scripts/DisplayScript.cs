using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScript : MonoBehaviour {

    // Player Camera = [0] || GameMaster Camera = [1]s
    [SerializeField] private Camera[] myCams;

	// Use this for initialization
	void Start () {
        if(Display.displays.Length > 1)
            Display.displays[1].Activate();
        Debug.Log("displays connected: " + Display.displays.Length);
    }
}
