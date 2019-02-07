using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [Header("Set time of Rounds")]
    [HideInInspector] public Text timerLabel;

    [HideInInspector] public float setTime;
    [HideInInspector] public float time;
    private float realTime;

    private float minutes;
    private float seconds;

    private void OnEnable()
    {
        timerLabel = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        timerLabel = GetComponentInChildren<Text>();
        SetTime();
    }

    public void SetTime()
    {
        time = setTime;
    }

    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        realTime = Mathf.FloorToInt(time);

        if (time > 60)
        {
            minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
        }
        else
        {
            minutes = 0;
        }
        seconds = time % 60; //Use the euclidean division for the seconds.

        //update the label value
        timerLabel.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
