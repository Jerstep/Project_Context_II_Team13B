using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour
{
    private List<GameObject> windows;

    [Header("UI Elements")]
    public GameObject canvas;
    public GameObject scoreScreen;
    public GameObject timer;
    public GameObject timesUp;
    public GameObject roundWindow;
    public GameObject tutorialWindow;

    public Animator animator;

    [Header("Managers")]
    public float openDelay;

    [Header("Managers")]
    public ScoreManager scoreManager;
    public WindowManager windowManager;
    public ChooseChairman chooseChairman;
    public Round round;
    public MoveCamera moveCamera;
    public SpawnPlayerCharacters spawnPlayers;

    public List<int> activePlayerCharacters;
    public List<Player> activePlayers;

    [Header("Score Vars")]
    public int amountPointSteps = 8;
    private float scoreAmount;
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
        //animator.SetTrigger("Clicked");
        StartCoroutine(ScoreOpenDelay());
        StartCoroutine(CloseWIthDelay(timesUp));
        StartCoroutine(CloseWIthDelay(roundWindow));
        StartCoroutine(CloseWIthDelay(tutorialWindow));
        StartCoroutine(CloseWIthDelay(timer));
        timer.GetComponent<TimerScript>().timerRunning = false;
        round.roundActive = false;

    }

    public void OnOpenLocationPressed()
    {
        //animator.SetTrigger("Clicked");
        StartCoroutine(OpenWIthDelay(windowManager.locationWindow));

        StartCoroutine(CloseWIthDelay(scoreManager.scoreScreen));
        StartCoroutine(CloseWIthDelay(scoreManager.gameMasterScoreScreen));

        StartCoroutine(CloseWIthDelay(timesUp));
        StartCoroutine(CloseWIthDelay(roundWindow));
        StartCoroutine(CloseWIthDelay(tutorialWindow));
        StartCoroutine(CloseWIthDelay(timer));
        timer.GetComponent<TimerScript>().timerRunning = false;
        round.roundActive = false;
    }


    public List<Player> GetPlayerScripts()
    {
        List<Player> playerList = new List<Player>();
        for(int i = 0; i < spawnPlayers.characters.Count; i++)
        {
            playerList.Add(spawnPlayers.characters[i].GetComponent<Player>());
        }
        return playerList;
    }

    public void AssignCharimanButton()
    {
        //chooseChairman.UnassignChairman(activePlayers);
        chooseChairman.AssignChairman(GetPlayerScripts());
    }

    public void AddButtonPressed(int charIndex)
    {
        scoreManager.AddScore(charIndex, scoreAmount);
    }

    public void SubtractButtonPressed(int charIndex)
    {
        scoreManager.SubtractScore(charIndex, scoreAmount);
    }

    IEnumerator OpenWIthDelay(GameObject window)
    {
        animator.SetTrigger("Clicked");
        yield return new WaitForSeconds(openDelay);
        window.SetActive(true);
    }

    IEnumerator OpenLocationDelay(GameObject window)
    {
        animator.SetTrigger("Clicked");
        yield return new WaitForSeconds(openDelay);
        window.SetActive(true);
    }

    IEnumerator CloseWIthDelay(GameObject window)
    {
        yield return new WaitForSeconds(openDelay);
        window.SetActive(false);
    }

    IEnumerator ScoreOpenDelay()
    {
        yield return new WaitForSeconds(openDelay);
        scoreManager.SetScoreScreensActiveDeactive();
    }
}
