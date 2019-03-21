using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //private int playerAmount;

    public List<int> charIndex;
    public GameObject[] characters;
    public List<GameObject> players;

    private static PlayerManager manager;
    public PlayerDestinations playerDes;

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

        for(int i = 0; i < charIndex.Count; i++)
        {
            for(int e = 0; e < characters.Length; e++)
            {
                if(charIndex[i] == e)
                {
                    spawnPlayers.SpawnCharacters(characters[i]);
                }
            }

            if(spawnPlayers.spawnIndex == charIndex.Count)
            {
                players = spawnPlayers.characters;
                playerDes.characters = players;
                cam.players = players;
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
