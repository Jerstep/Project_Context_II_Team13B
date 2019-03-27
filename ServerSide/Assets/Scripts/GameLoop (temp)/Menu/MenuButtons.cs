using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject charSelectMenu;
    public GameObject intro;
    public GameObject mainMenu;

    bool mainMenuActive = true;
    bool CharMenuActive = false;

    public void StartButton()
    {
        mainMenuActive = !mainMenuActive;
        mainMenu.SetActive(mainMenuActive);
        intro.SetActive(true);
    }

    public void OptionsButton()
    {
        Debug.Log("Options Button Pressed!!");
    }

    public void ContinueButton()
    {
        CharMenuActive = !CharMenuActive;
        charSelectMenu.SetActive(CharMenuActive);
        Debug.Log("Continue Button Pressed!!");
    }

    public void ExitButton()
    {
        Debug.Log("Exiting game");
        Application.Quit();
    }

    public void BackButton()
    {
        mainMenuActive = !mainMenuActive;
        CharMenuActive = !CharMenuActive;
        charSelectMenu.SetActive(CharMenuActive);
        mainMenu.SetActive(mainMenuActive);
    }
}


