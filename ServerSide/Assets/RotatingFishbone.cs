using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingFishbone : MonoBehaviour {
    public AnimationCurve myCurve;
    float thisTransform;

    private void Start()
    {
        thisTransform = this.transform.position.y;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, thisTransform + myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }
}
