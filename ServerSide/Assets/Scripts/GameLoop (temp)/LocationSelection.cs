using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationSelection : MonoBehaviour
{
    public SpawnPlayerCharacters characters;
    public List<GameObject> players;
    public Location[] location;
    public GameObject[] buttons;

    public GameObject locationWindow;
    //public GameManager gameManager;

    void Start ()
    {
        players = characters.characters;
    }

    private void Update()
    {
        StartCoroutine("CheckAvailebleStatements");
    }

    public void LocationButton1()
    {
        Debug.Log("Pressed L 1");
        for(int i = 0; i < players.Count; i++)
        {
            players[i].transform.position = location[0].GetSpawnPosition()[i];
        }
        Debug.Log(location[0].isActive);
    }

    public void LocationButton2()
    {
        Debug.Log("Pressed L 2");
        for(int i = 0; i < players.Count; i++)
        {
            players[i].transform.position = location[1].GetSpawnPosition()[i];
        }
        Debug.Log(location[1].isActive);
    }
}
