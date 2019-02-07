using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject themaTextObject;
    public GameObject timesUpScreen;


    [Tooltip("00 Seconds, 0000 Minutes")] public GameObject timer;

    public float SetTime;
    public float waitTime;

    bool started = false;

	// Use this for initialization
	void Start () {
        timer.GetComponent<Timer>().setTime = SetTime;
    }

    private void Update()
    {
        if (timer.GetComponent<Timer>().time <= 0 && started)
        {
            TimesUp();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(timesUpScreen.active == true)
            {
                DisapbleTimesUpScreen();
            }
        }
    }

    public void StartGame()
    {
        themaTextObject.SetActive(true);
    }

    public void StartTimer()
    {
        timer.SetActive(true);
        timer.GetComponent<Timer>().SetTime();
        started = true;
        Debug.Log(started);
    }

    public void TimesUp()
    {
        timesUpScreen.SetActive(true);
        timer.SetActive(false);
    }

    private void DisapbleTimesUpScreen()
    {
        timesUpScreen.SetActive(false);
        timer.GetComponent<Timer>().SetTime();
        timer.SetActive(true);
        Debug.Log(SetTime);
    }
}
