using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingFishbone : MonoBehaviour {
    public AnimationCurve myCurve;
    private Vector3 thisTransform;

    private void Start()
    {
        thisTransform = this.transform.position;
    }

    private void Update()
    {
        StartCoroutine("randomJump");
    }

    IEnumerator randomJump()
    {
        yield return new WaitForSeconds(Random.Range(0, 1));
        transform.position = new Vector3(transform.position.x, thisTransform.y + myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }
}
