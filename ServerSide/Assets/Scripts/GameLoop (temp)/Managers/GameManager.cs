using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{



    //	void Start ()
    //    {
    //        locationWindow.SetActive(true);
    //    }

    //    void FixedUpdate()
    //    {
    //        StartCoroutine("WaitForNextCheck");
    //    }

    //    IEnumerator WaitForNextCheck()
    //    {
    //        yield return new WaitForSeconds(1);
    //        //if(!round.UI_TimeIsUp.activeSelf)
    //        //{
    //        //    roundFinished = true;
    //        //}

    //        if(locationActive && !roundActive)
    //        {
    //            Debug.Log(GetAciveLocation().gameObject.name);
    //            SetStatementWindow();
    //        }

    //        if(round.roundTime <= 0 && round.UI_TimeIsUp.activeSelf)
    //        {
    //            StartCoroutine("WaitTillScreenGone");
    //        }

    //        //if(roundFinished)
    //        //{
    //        //    locationWindow.SetActive(true);
    //        //}

    //        //if(!roundWindow.activeSelf )
    //        //{
    //        //    roundActive = false;
    //        //}
    //    }
    //    public void NewLocation()
    //    {
    //        GetAciveLocation();
    //    }

    //    void SetStatementWindow()
    //    {
    //        currentLocation = GetAciveLocation();
    //        statementWindow.SetActive(true);
    //        for(int i = 0; i < currentLocation.statements.Length; i++)
    //        {
    //            if(!currentLocation.statements[i].hasBeenChosen)
    //            {
    //                UI_Choise[i].SetActive(true);
    //                UI_Choise[i].GetComponentInChildren<TMP_Text>().text = currentLocation.statements[i].statementText;
    //            }
    //        }
    //    }

    //    void DeactivateStatements()
    //    {
    //        for(int i = 0; i < UI_Choise.Length; i++)
    //        {
    //            UI_Choise[i].SetActive(false);
    //        }
    //    }

    //    private Location GetAciveLocation()
    //    {
    //        for(int i = 0; i < locations.Length; i++)
    //        {
    //            //Debug.Log(locations[i].isActive);
    //            if(locations[i].isActive)
    //            {
    //                locationActive = true;
    //                return locations[i];
    //            }
    //        }
    //        return null;
    //    }

    //    // Cause we are running out of time I put the managements of the statment buttons here.
    //    public void OnStatementButtonPressed()
    //    {
    //        roundActive = true;
    //        DeactivateStatements();
    //        locationWindow.SetActive(false);
    //        roundWindow.SetActive(true);

    //        int buttonClickedIndex = System.Array.IndexOf(UI_Choise, EventSystem.current.currentSelectedGameObject);
    //        Statement chosenStatement = currentLocation.statements[buttonClickedIndex];
    //        round.CurrentStatement(chosenStatement);
    //    }

    //    IEnumerator WaitTillScreenGone()
    //    {
    //        locationActive = false;
    //        statementWindow.SetActive(false);
    //        yield return new WaitForSeconds(round.timeIsUpTime);
    //        locationWindow.SetActive(true);
    //        roundActive = false;
    //    }
}
