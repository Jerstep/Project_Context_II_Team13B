using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject locationWindow;
    public Location[] locations;

    public GameObject statementWindow1;
    public GameObject statementWindow2;
    public GameObject statementWindow3;
    public Statements statements;

    public GameObject roundWindow;
    public Round round;

    public PlayerDestinations playerDes;

    public int transitionTime;
    private bool roundActive = false;
    private bool inputGiven = false;

    private void Start()
    {
        playerDes = GetComponent<PlayerDestinations>();
    }

    private void Update()
    {
        if(round.roundActive)
        {
            StartCoroutine(TimeBeforeRoundOver());
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            locationWindow.SetActive(true);
            inputGiven = true;
        }
    }

    private void LocationsWindow()
    {
        locationWindow.SetActive(true);
        statementWindow1.SetActive(false);
        statementWindow2.SetActive(false);
        roundWindow.SetActive(false);
    }

    public void OnLocation1Button()
    {
        StartCoroutine(waitBeforeOpenWindow(statementWindow1));
        statements = statementWindow1.GetComponent<Statements>();
        round.CurrentStatement(statements.ChooseRandomStatement());

        statementWindow2.SetActive(false);
        statementWindow3.SetActive(false);
        locationWindow.SetActive(false);
        roundWindow.SetActive(true);
        roundActive = true;

        playerDes.arrival = locations[0].GetSpawnPosition();
        playerDes.destinations = locations[0].GetTargetLocation();
        playerDes.AssignPlayerArrival();
        playerDes.AssignPlayerDestination();
    }

    public void OnLocation2Button()
    {
        StartCoroutine(waitBeforeOpenWindow(statementWindow2));
        statements = statementWindow2.GetComponent<Statements>();
        round.CurrentStatement(statements.ChooseRandomStatement());

        statementWindow1.SetActive(false);
        statementWindow3.SetActive(false);
        locationWindow.SetActive(false);
        roundWindow.SetActive(true);
        roundActive = true;

        playerDes.arrival = locations[1].GetSpawnPosition();
        playerDes.destinations = locations[1].GetTargetLocation();
        playerDes.AssignPlayerArrival();
        playerDes.AssignPlayerDestination();
    }

    public void OnLocation3Button()
    {
        StartCoroutine(waitBeforeOpenWindow(statementWindow3));
        statements = statementWindow3.GetComponent<Statements>();
        round.CurrentStatement(statements.ChooseRandomStatement());

        statementWindow1.SetActive(false);
        statementWindow2.SetActive(false);
        locationWindow.SetActive(false);
        roundWindow.SetActive(true);
        roundActive = true;

        playerDes.arrival = locations[2].GetSpawnPosition();
        playerDes.destinations = locations[2].GetTargetLocation();
        playerDes.AssignPlayerArrival();
        playerDes.AssignPlayerDestination();
    }

    //public void SetStatementWindow()
    //{
    //    int buttonClickedIndex = System.Array.IndexOf(statements.buttons, EventSystem.current.currentSelectedGameObject);
    //    Statement chosenStatement = statements.statements[buttonClickedIndex];
    //    round.CurrentStatement(chosenStatement);
    //    statements.buttons[buttonClickedIndex].SetActive(false);

    //    roundWindow.SetActive(true);
    //    roundActive = true;
    //    statementWindow1.SetActive(false);
    //    statementWindow2.SetActive(false);
    //    locationWindow.SetActive(false);
    //}

    IEnumerator waitBeforeOpenWindow(GameObject window)
    {
        yield return new WaitForSeconds(transitionTime);
        window.SetActive(true);
    }

    IEnumerator TimeBeforeRoundOver()
    {
        float waitTime = round.roundTime + round.timeIsUpTime;
        yield return new WaitForSeconds(waitTime);
        //StartCoroutine(AfterRound());
    }

    //IEnumerator AfterRound()
    //{
    //    bool inputGiven = false;
    //    while(!inputGiven)
    //    {
    //        Debug.Log("Waiting for input");
    //        if(Input.GetKeyDown(KeyCode.Space))
    //        {
    //            locationWindow.SetActive(true);
    //            inputGiven = true;
    //        }
    //        yield return null;
    //    }
    //}
}
