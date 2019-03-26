using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject scoreScreen;
    public int amountPointSteps;
    private float scoreAmount;

    public List<int> activePlayerCharacters;

    // Use this for initialization
    private void Start () {
        scoreAmount = 1f / amountPointSteps;
    }

    private void OnLevelWasLoaded()
    {
        canvas = GameObject.Find("GameMasterCanvas");
    }

    public void OnContinuePressed()
    {

    }

    public void AddButtonPressed(int charIndex)
    {

    }

    public void SubtractButtonPressed(int charIndex)
    {

    }
}
