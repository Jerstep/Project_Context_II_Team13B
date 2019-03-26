using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowManager : MonoBehaviour {

    // Voor easys sake maak gewoon een aantal windows met knoppen voor de locaties.
    // Geen tijd om super dinamisch te doen
//__________________________________________________________________________________//

    // Als Location open is: Statements, Round gesloten
    // Als Statements open is: Location, Round gesloten
    // Als Round open is: Location, Statements gesloten

    // Reffrences naar BELANGERIJKE scripts/managers
        // Round
        // GameManager :: Kan mischien beter een ref hebben naar dit dan andersom
        // 

    // Window GameObjects :: UI
        // Locatie window object 
        // Window voor statement ( die kan wel worden gegenereerd met code )
            // Met de knop zet je de text van de statement die gekozen word.
            //  EventSystem.current.currentSelectedGameObject


    // Button Management :: UI/Interact

    public GameObject canvas;
    public GameObject locationWindow;
    public Location[] locations;

    public GameObject statementWindow1;
    public GameObject statementWindow2;
    public Statements statements;

    public GameObject roundWindow;
    public Round round;

    public PlayerDestinations playerDes;

    public int transitionTime;
    private bool roundActive = false;
    private bool inputGiven = false;

    //bool statementOpen;
    //bool locationOpen;
    //bool roundOpen;

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

        CloseAllExeptSelected();
    }

    public void OnLocation1Button()
    {
        StartCoroutine(waitBeforeOpenWindow(statementWindow1));
        statements = statementWindow1.GetComponent<Statements>();

        statementWindow2.SetActive(false);
        roundWindow.SetActive(false);
        locationWindow.SetActive(false);

        playerDes.arrival = locations[0].GetSpawnPosition();
        playerDes.destinations = locations[0].GetTargetLocation();
        playerDes.AssignPlayerArrival();
        playerDes.AssignPlayerDestination();
    }

    public void OnLocation2Button()
    {
        StartCoroutine(waitBeforeOpenWindow(statementWindow2));
        statements = statementWindow2.GetComponent<Statements>();

        statementWindow1.SetActive(false);
        roundWindow.SetActive(false);
        locationWindow.SetActive(false);

        playerDes.arrival = locations[1].GetSpawnPosition();
        playerDes.destinations = locations[1].GetTargetLocation();
        playerDes.AssignPlayerArrival();
        playerDes.AssignPlayerDestination();
    }

    public void SetStatementWindow()
    {
        int buttonClickedIndex = System.Array.IndexOf(statements.buttons, EventSystem.current.currentSelectedGameObject);
        Statement chosenStatement = statements.statements[buttonClickedIndex];
        round.CurrentStatement(chosenStatement);
        statements.buttons[buttonClickedIndex].SetActive(false);

        roundWindow.SetActive(true);
        roundActive = true;
        statementWindow1.SetActive(false);
        statementWindow2.SetActive(false);
        locationWindow.SetActive(false);
    }

    private void CloseAllExeptSelected()
    {


    }

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
