using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public bool isChairman = false;
    private string charName;
    public TMP_Text text;

    private void Start()
    {
        charName = text.text;
        Debug.Log(text);
        SetChairman("Chariman");
    }

    public void SetChairman(string chairman)
    {
        if(isChairman)
        {
            text.text = charName + " " + chairman;
        }
        else
        {
            text.text = charName;
        }
    }

}
