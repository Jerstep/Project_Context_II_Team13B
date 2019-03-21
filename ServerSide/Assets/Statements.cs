using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Statements : MonoBehaviour {
    public Statement[] statements;
    public GameObject[] buttons;
    private int amountInactive = 0;
    public bool allStatementsDone = false;

    private void Start()
    {
        for(int i = 0; i < statements.Length; i++)
        {
            buttons[i].GetComponentInChildren<TMP_Text>().text = statements[i].statementText;
        }
    }

    private void CheckStatements()
    {
        for(int i = 0; i < statements.Length; i++)
        {
            if(statements[i].hasBeenChosen)
            {
                amountInactive++;
            }

            if(amountInactive == statements.Length)
            {
                allStatementsDone = true;
            }
        }
    }


}
