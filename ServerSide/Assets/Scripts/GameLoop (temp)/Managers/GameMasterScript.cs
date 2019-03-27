using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject scoreScreen;
    public GameObject timesUp;
    public GameObject roundWindow;
    public int amountPointSteps = 8;
    private float scoreAmount;

    public ScoreManager scoreManager;
    public WindowManager windowManager;
    ChooseChairman chooseChairman = new ChooseChairman();
    public List<int> activePlayerCharacters;
    public List<Player> activePlayers;

    // Use this for initialization
    private void Start ()
    {
        scoreAmount = 1f / amountPointSteps;
    }

    private void OnLevelWasLoaded()
    {
        canvas = GameObject.Find("GameMasterCanvas");
    }

    public void OnToScored()
    {
        scoreManager.SetScoreScreensActiveDeactive();
        timesUp.SetActive(false);
        roundWindow.SetActive(false);
    }

    public void OnOpenLocationPressed()
    {
        scoreManager.scoreScreen.SetActive(false);
        windowManager.locationWindow.SetActive(true);
        timesUp.SetActive(false);
        roundWindow.SetActive(false);
    }

    public void AssignCharimanButton()
    {
        chooseChairman.AssignChairman(activePlayers);
    }

    public void AddButtonPressed(int charIndex)
    {
        scoreManager.AddScore(charIndex, scoreAmount);
    }

    public void SubtractButtonPressed(int charIndex)
    {
        scoreManager.SubtractScore(charIndex, scoreAmount);
    }
}
