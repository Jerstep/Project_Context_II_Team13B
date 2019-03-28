using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDestinations : MonoBehaviour {

    public List<GameObject> characters;
    public Vector3[] destinations;
    public Vector3[] arrival;
    public int playerIndex;

    public void AssignPlayerArrival()
    {
        if(characters != null)
        {
            for(int i = 0; i < characters.Count; i++)
            {
                characters[i].GetComponent<NavMeshAgent>().Warp(arrival[i]);
                //characters[i].gameObject.transform.position = arrival[i];
            }
        }
    }

    public void AssignPlayerDestination()
    {
        if(characters != null)
        {
            for(int i = 0; i < characters.Count; i++)
            {                
                characters[i].GetComponent<Player>().SetDestinationForAgent(destinations[i]);
            }
        }
    }
}
