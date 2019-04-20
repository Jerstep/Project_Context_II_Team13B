using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowManager : MonoBehaviour
{
    [Header("Main Objects")]
    public GameObject canvas;
    public GameObject locationWindow;
    public Location[] locations;

    [Header("UI Windows")]
    public GameObject statementWindow1;
    public GameObject statementWindow2;
    public GameObject statementWindow3;
    public Animator animator;
    public Statements statements;


    public GameObject roundWindow;
    public Round round;

    public PlayerDestinations playerDes;

    [Header("Delay Times")]
    public float statementTransitionTime;
    public float positionTransitionTime;

    private bool roundActive = false;
    private bool inputGiven = false;

    private void Start()
    {
        playerDes = GetComponent<PlayerDestinations>();
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
        StartCoroutine(setStatementsDelay(statementWindow1.GetComponent<Statements>()));
        StartCoroutine(setLocationDelay(playerDes, locations[0]));
        //statements = statementWindow1.GetComponent<Statements>();
        //round.CurrentStatement(statements.ChooseRandomStatement());

        locationWindow.SetActive(false);
        StartCoroutine(SetRoundActive());
        Transition();


        //playerDes.arrival = locations[0].GetSpawnPosition();
        //playerDes.destinations = locations[0].GetTargetLocation();
        //playerDes.AssignPlayerArrival();
        //playerDes.AssignPlayerDestination();
    }

    public void OnLocation2Button()
    {
        StartCoroutine(setStatementsDelay(statementWindow2.GetComponent<Statements>()));
        StartCoroutine(setLocationDelay(playerDes, locations[1]));
        //statements = statementWindow2.GetComponent<Statements>();
        //round.CurrentStatement(statements.ChooseRandomStatement());

        locationWindow.SetActive(false);
        StartCoroutine(SetRoundActive());
        Transition();


        //playerDes.arrival = locations[1].GetSpawnPosition();
        //playerDes.destinations = locations[1].GetTargetLocation();
        //playerDes.AssignPlayerArrival();
        //playerDes.AssignPlayerDestination();
    }

    public void OnLocation3Button()
    {
        StartCoroutine(setStatementsDelay(statementWindow3.GetComponent<Statements>()));
        StartCoroutine(setLocationDelay(playerDes, locations[2]));
        //statements = statementWindow3.GetComponent<Statements>();
        //round.CurrentStatement(statements.ChooseRandomStatement());

        locationWindow.SetActive(false);
        Transition();
        StartCoroutine(SetRoundActive());

        //playerDes.arrival = locations[2].GetSpawnPosition();
        //playerDes.destinations = locations[2].GetTargetLocation();
        //playerDes.AssignPlayerArrival();
        //playerDes.AssignPlayerDestination();
    }

    private void Transition()
    {
        if(animator != null)
        {
           animator.SetTrigger("Clicked");
        }
    }

    IEnumerator setStatementsDelay(Statements _statements)
    {
        yield return new WaitForSeconds(statementTransitionTime);
        statements = _statements;
        round.CurrentStatement(statements.ChooseRandomStatement());
    }

    IEnumerator SetRoundActive()
    {
        yield return new WaitForSeconds(statementTransitionTime);

        roundWindow.SetActive(true);
        //round.UI_Statement.SetActive(true);
        roundActive = true;
    }

    IEnumerator setLocationDelay(PlayerDestinations playerDestination , Location location)
    {
        yield return new WaitForSeconds(positionTransitionTime);
        playerDestination.arrival = location.GetSpawnPosition();
        playerDestination.destinations = location.GetTargetLocation();

        playerDes.AssignPlayerArrival();
        playerDes.AssignPlayerDestination();

    }
}
