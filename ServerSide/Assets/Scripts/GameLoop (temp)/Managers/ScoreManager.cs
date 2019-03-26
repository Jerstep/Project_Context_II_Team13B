using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    // Needs UI elements for all participating Chars.
    // Use vertival UI Layout Group for spacing ( is easyest )
    // Get the score from the current statement send to a method to save.
    // Assign to char that won ( Needs to be in gamemaster part.
    // Can also simply be a + and - button for every char.
    // Show diffrent UI to GameMaster ( same but then with the + and -

    // After Confirm open the location window again :)


    public List<int> charIndex;
    public GameObject scoreScreen;
    public GameObject gameMasterScoreScreen;
    public GameObject[] playerScoreSliders;

    private bool active = false;

    // Use this for initialization
    public void SetScoreScreensActiveDeactive()
    {
        scoreScreen.SetActive(!active);
        gameMasterScoreScreen.SetActive(!active);
    }

    public void SetSlidersActive()
    {
        for(int i = 0; i < playerScoreSliders.Length; i++)
        {
            if(charIndex[i] == i)
            {
                playerScoreSliders[i].SetActive(true);
            }
            else
            {
                playerScoreSliders[i].SetActive(false);
            }
        }
    }
}
