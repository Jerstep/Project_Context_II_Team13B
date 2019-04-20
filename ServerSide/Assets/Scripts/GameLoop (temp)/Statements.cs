using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Statements : MonoBehaviour
{
    public Statement[] statements;
    public GameObject[] buttons;
    private int amountInactive = 0;
    public bool allStatementsDone = false;
    int randomIndex;


    //private void Start()
    //{
    //    for(int i = 0; i < statements.Length; i++)
    //    {
    //        buttons[i].GetComponentInChildren<TMP_Text>().text = statements[i].statementText;
    //    }
    //}
    

    public Statement ChooseRandomStatement()
    {
        if(randomIndex < statements.Length)
        {
            randomIndex++;
        }
        else
        {
            randomIndex = 0;
        }
        return statements[randomIndex];
    }

    //private void CheckStatements()
    //{
    //    bool foundOpenStatement = false;
    //    int randomIndex = Random.Range(0,statements.Length);

    //    while(foundOpenStatement == false)
    //    {
    //        randomIndex = Random.Range(0, statements.Length);
    //        if(statements[randomIndex].hasBeenChosen == false)
    //        {
    //            return randomIndex;
    //        }
    //    }
    //    return randomIndex;
    //}

    IEnumerator CheckStateStatur()
    {
        int correctIndex;

        bool foundOpenStatement = false;
        int randomIndex = Random.Range(0, statements.Length);

        while(foundOpenStatement == false)
        {
            randomIndex = Random.Range(0, statements.Length);
            if(statements[randomIndex].hasBeenChosen == false)
            {
                correctIndex = randomIndex;
            }
        }
        yield return null;
    }

}
