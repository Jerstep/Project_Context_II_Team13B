using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public List<GameObject> players;
    private Vector3 startPos;
    public Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        startPos = this.transform.position;
    }

    private void Update()
    {
        SetCameraPos();
    }

    void SetCameraPos()
    {
        Vector3 middle = Vector3.zero;
        int numPlayers = 0;

        for(int i = 0; i < players.Count; ++i)
        {
            if(players[i] == null)
            {
                continue; //skip, since player is deleted
            }
            middle += players[i].transform.position;
            Debug.Log(middle);  
            numPlayers++;
        }//end for every player

        //take average:
        middle /= numPlayers;
        cam.transform.position = new Vector3(middle.x + startPos.x, transform.position.y, middle.z + startPos.z);
    }

 }
