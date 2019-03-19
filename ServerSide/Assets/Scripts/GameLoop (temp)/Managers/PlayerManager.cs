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

	void Start () {
        //manager = this;
        DontDestroyOnLoad(this);
	}

    private void OnLevelWasLoaded()
    {
        SpawnPlayerCharacters spawnPlayers = GameObject.Find("GameManager").GetComponent<SpawnPlayerCharacters>();
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
            }
        }
    }


    // DEBUG TEST CHAR LIST!!
    public void charIndexUpdate()
    {
        for(int i = 0; i < charIndex.Count; i++)
        {
            Debug.Log("Character Index in list: " + charIndex[i]);
        }

        if(charIndex.Count == 0)
        {
            Debug.Log("Empty");
        }
    }
}
