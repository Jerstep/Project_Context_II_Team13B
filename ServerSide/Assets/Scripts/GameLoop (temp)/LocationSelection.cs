using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationSelection : MonoBehaviour {

    public SpawnPlayerCharacters characters;
    public List<GameObject> players;
    public Location[] location;


	void Start () {
        players = characters.characters;
	}

    public void LocationButton1()
    {
        Debug.Log("Pressed L 1");
        for(int i = 0; i < players.Count; i++)
        {
            players[i].transform.position = location[0].GetSpawnPosition()[i];
        }
    }

    public void LocationButton2()
    {
        Debug.Log("Pressed L 2");
        for(int i = 0; i < players.Count; i++)
        {
            players[i].transform.position = location[1].GetSpawnPosition()[i];
        }
    }

    public void DisableOnClick()
    {
        this.gameObject.SetActive(false);
    }

}
