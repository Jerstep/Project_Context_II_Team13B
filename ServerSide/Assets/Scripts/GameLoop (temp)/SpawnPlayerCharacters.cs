using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SpawnPlayerCharacters : MonoBehaviour
{
    public Transform[] spawnLocations;

    public List<GameObject> characters;
    public GameObject charHolder;

    public int spawnIndex;

    public void SpawnCharacters(GameObject character)
    {
        Transform location = spawnLocations[spawnIndex];
        GameObject Char = Instantiate(character, location.position, location.rotation);
        characters.Add(Char);
        if(spawnIndex < spawnLocations.Length)
        {
            spawnIndex++;
        }
        //Debug.Log("Instantiated char: " + Char.name);
    }
}
