using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class LocationManager : MonoBehaviour {

    public Location[] locations;

    public GameObject UI_Window;
    public GameObject UI_Title;
    public GameObject UI_Choises;

    public Canvas canvas;

    private void CreateChoiseUI()
    {
        //GameObject window = Instantiate(UI_Window, canvas.transform);
        //GameObject title = Instantiate(UI_Title, window.transform);

        //title.GetComponentInChildren<TMP_Text>().text = "LOCATIONS";

        //for(int i = 0; i < locations.Length; i++)
        //{
        //    GameObject choises = Instantiate(UI_Choises, window.transform);
        //    TMP_Text choiseText = choises.GetComponentInChildren<TMP_Text>();
        //    choiseText.text = locations[i].GetName();
        //}
    }

    // Use this for initialization
    void Start () {
        CreateChoiseUI();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
