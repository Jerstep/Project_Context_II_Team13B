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
    public PlayerDestinations playerDes;
    public GameMasterScript gameMasterScript;
    public ScoreManager scoreManager;

    public MoveCamera cam;

    void Start () {
        //manager = this;
        DontDestroyOnLoad(this);        
	}

    private void OnLevelWasLoaded()
    {
        cam = GameObject.Find("MainCamera").GetComponent<MoveCamera>();

        SpawnPlayerCharacters spawnPlayers = GameObject.Find("GameManager").GetComponent<SpawnPlayerCharacters>();
        playerDes = GameObject.Find("GameManager").GetComponent<PlayerDestinations>();
        gameMasterScript = GameObject.Find("GameManager").GetComponent<GameMasterScript>();
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        gameMasterScript.activePlayerCharacters = charIndex;
        scoreManager.charIndex = charIndex;

        for(int i = 0; i < charIndex.Count; i++)
        {
            for(int e = 0; e < characters.Length; e++)
            {
                if(charIndex[i] == e)
                {
                    spawnPlayers.SpawnCharacters(characters[i]);
                    playersScripts.Add(characters[i].GetComponent<Player>());
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
    }

    // DEBUG TEST CHAR LIST!!
    //public void charIndexUpdate()
    //{
    //    for(int i = 0; i < charIndex.Count; i++)
    //    {
    //        Debug.Log("Character Index in list: " + charIndex[i]);
    //    }

    //    if(charIndex.Count == 0)
    //    {
    //        Debug.Log("Empty");
    //    }
    //}
}
