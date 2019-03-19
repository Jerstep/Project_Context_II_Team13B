using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class Round : MonoBehaviour
{
    public int waitTime;
    public string statementTitle;
    public string[] statements;

    public GameObject choiseUIMenu;
    public GameObject choiseUIChoisePanel;

    private void CreateChoiseUI()
    {
        GameObject choiseMenu =  Instantiate(choiseUIMenu);
        for(int i = 0; i < statements.Length; i++)
        {
            GameObject choisePanel = Instantiate(choiseUIChoisePanel);
            choisePanel.transform.parent = choiseMenu.transform;

            TMP_Text choiseText = choisePanel.GetComponent<TMP_Text>();
            choiseText.text = statements[i];
        }
    }

	void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
