using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public bool timerRunning = false;

    public void RoundStart(float time, Image timeBar)
    {
        float maxTime = time;
        StartCoroutine(StartTimer(maxTime, time, timeBar));
    }

    public void RoundOver(GameObject timeIsUp, float roundOver)
    {
        StartCoroutine(TimeIsUp(timeIsUp, roundOver));
    }

    IEnumerator StartTimer(float maxTime, float time, Image timeBar)
    {
        //Debug.Log("Timer Active = " + timerRunning);
        if(time > 0)
        {
            timerRunning = true;
        }

        while(timerRunning)
        {
            time -= Time.deltaTime;
            timeBar.fillAmount = time / maxTime;

            if(time < 0)
            {
                Debug.Log(Mathf.RoundToInt(time));    
                timerRunning = false;
            }
            yield return null;
        }
    }

    IEnumerator TimeIsUp(GameObject timeIsUp, float roundOver)
    {
        timeIsUp.SetActive(true);
        yield return new WaitForSeconds(roundOver);
    }
}
