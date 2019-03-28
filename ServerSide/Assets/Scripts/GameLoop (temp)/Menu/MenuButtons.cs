using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject charSelectMenu;
    public GameObject intro;
    public GameObject mainMenu;

    public Animator animator;

    bool mainMenuActive = true;
    bool CharMenuActive = false;


    public float openDelay;

    public void StartButton()
    {
        //mainMenuActive = !mainMenuActive;
        StartCoroutine(CloseWIthDelay(mainMenu));
        //intro.SetActive(true);
        StartCoroutine(OpenWIthDelay(intro));
    }

    public void OptionsButton()
    {
        Debug.Log("Options Button Pressed!!");
    }

    public void ContinueButton()
    {
        // CharMenuActive = !CharMenuActive;
        //charSelectMenu.SetActive(CharMenuActive);
        StartCoroutine(OpenWIthDelay(charSelectMenu));
        StartCoroutine(CloseWIthDelay(intro));
        StartCoroutine(CloseWIthDelay(mainMenu));
        //intro.SetActive(false);
        Debug.Log("Continue Button Pressed!!");
        //animator.SetTrigger("Clicked");
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

    IEnumerator OpenWIthDelay(GameObject window)
    {
        animator.SetTrigger("clicked");
        yield return new WaitForSeconds(openDelay);
        window.SetActive(true);
    }

    IEnumerator CloseWIthDelay(GameObject window)
    {
        animator.SetTrigger("clicked");
        yield return new WaitForSeconds(openDelay);
        window.SetActive(false);
    }
}


