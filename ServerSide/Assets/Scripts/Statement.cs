using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statement : MonoBehaviour
{
    public bool hasBeenChosen = false;
    public string statement;
    public int score;

    public int GetScoreAmount()
    {
        return score;
    }

    public void SetActiveUnactive()
    {
        if(hasBeenChosen)
        {
            this.gameObject.SetActive(false);
        }
    }
}
