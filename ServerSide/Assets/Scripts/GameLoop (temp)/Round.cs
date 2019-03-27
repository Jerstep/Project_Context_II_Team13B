using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Round : MonoBehaviour
{
    public GameObject UI_Title;
    public GameObject UI_Statement;
    public GameObject UI_TimeIsUp;

    public TimerScript timerScript;
    public GameObject timer;
    public Image timeBar;

    public bool roundActive = false;
    
    public float roundTime;
    public float timeIsUpTime;
    public Statement statement;

    public void CurrentStatement(Statement statement)
    {
        roundActive = true;

        if(statement.title != "")
        {
            // Sets the title of the type of round
            UI_Title.GetComponentInChildren<TMP_Text>().text = statement.title;
        }
        else
        {
            UI_Title.SetActive(false);
        }

        // Sets the statement/question to the one given in the function call.
        UI_Statement.GetComponentInChildren<TMP_Text>().text = statement.statementText;

        roundTime = statement.timeToDiscuss;
        statement.hasBeenChosen = true;
    }

    private void Update()
    {
        if(roundActive)
        {
            RoundTimer();
        }
    }

    private void RoundTimer()
    {
        timer.SetActive(true);
        timerScript.RoundStart(roundTime, timeBar);
        roundTime -= Time.deltaTime;

        if (roundTime < 0)
        {
            timerScript.RoundOver(UI_TimeIsUp, timeIsUpTime);
            UI_Statement.SetActive(false);
            timer.SetActive(false);
            roundActive = false;
        }
    }
}
