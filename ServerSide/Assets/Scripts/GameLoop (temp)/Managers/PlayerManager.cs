using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
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
    public GameObject[] characters;
    public List<GameObject> players;
    public List<Player> playersScripts;

    private static PlayerManager manager;
    private PlayerDestinations playerDes;
    private GameMasterScript gameMasterScript;
    private ScoreManager scoreManager;
    private SpawnPlayerCharacters spawnPlayers;
    private ChooseChairman chooseChairman;

    public MoveCamera cam;

    void Start () {
        //manager = this;
        DontDestroyOnLoad(this);        
	}

    private void OnLevelWasLoaded()
    {
        cam = GameObject.Find("MainCamera").GetComponent<MoveCamera>();

        GameObject gm = GameObject.Find("GameManager");

        spawnPlayers = gm.GetComponent<SpawnPlayerCharacters>();
        playerDes = gm.GetComponent<PlayerDestinations>();
        gameMasterScript = gm.GetComponent<GameMasterScript>();
        scoreManager = gm.GetComponent<ScoreManager>();
        chooseChairman = gm.GetComponent<ChooseChairman>();

        SetPlayerChars();
        
        gameMasterScript.activePlayerCharacters = charIndex;
        scoreManager.charIndex = charIndex;
    }

    void SetPlayerChars()
    {
        for(int i = 0; i < characters.Length; i++)
        {
            for(int e = 0; e < charIndex.Count; e++)
            {
                if(charIndex[e] == i)
                {
                    //Debug.Log(characters[charIndex[e]].name);
                    spawnPlayers.SpawnCharacters(characters[charIndex[e]]);
                    playersScripts.Add(characters[charIndex[e]].GetComponent<Player>());
                }
            }

            if(spawnPlayers.spawnIndex == charIndex.Count)
            {
                players = spawnPlayers.characters;
                playerDes.characters = players;
                cam.players = players;
                gameMasterScript.activePlayers = playersScripts;
            }
        }
        chooseChairman.AssignChairman(playersScripts);
    }
}
