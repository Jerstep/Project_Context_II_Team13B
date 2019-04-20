using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    /* 
     Index Characters:
        - Bee = [0]
        - Duck = [1]
        - Human = [2]
        - lion = [3]
        - Monkey = [4]
        - Shark = [5]
    */

    public List<int> charIndex;
    public GameObject scoreScreen;
    public GameObject gameMasterScoreScreen;
    public GameObject[] playerScoreSliders;
    public GameObject[] gameMasterScoreButtons;

    private bool active = false;

    // Use this for initialization
    public void SetScoreScreensActiveDeactive()
    {
        scoreScreen.SetActive(!active);
        gameMasterScoreScreen.SetActive(!active);
        SetSlidersActive();
    }

    public void SetSlidersActive()
    {
        for(int i = 0; i < charIndex.Count; i++)
        {
            for(int e = 0; e < playerScoreSliders.Length; e++)
            {
                if(charIndex.Contains(e))
                {
                    Debug.Log(i);
                    playerScoreSliders[e].SetActive(true);
                    gameMasterScoreButtons[e].SetActive(true);
                }
            }
        }

        //for(int i = 0; i < playerScoreSliders.Length; i++)
        //{
        //    Debug.Log(charIndex[i]);
        //    if(charIndex[i] == i)
        //    {
        //        playerScoreSliders[i].SetActive(true);
        //        gameMasterScoreButtons[i].SetActive(true);
        //    }
        //}
    }

    public void AddScore(int index, float score)
    {
        for(int i = 0; i < playerScoreSliders.Length; i++)
        {
            if(index == i)
            {
                if(playerScoreSliders[i].GetComponent<Slider>().value < 1)
                {
                    playerScoreSliders[i].GetComponent<Slider>().value += score;
                }
            }
        }
    }
    public void SubtractScore(int index, float score)
    {
        for(int i = 0; i < playerScoreSliders.Length; i++)
        {
            if(index == i)
            {
                if(playerScoreSliders[i].GetComponent<Slider>().value > 0)
                {
                    playerScoreSliders[i].GetComponent<Slider>().value -= score;
                }
            }
        }
    }
}
