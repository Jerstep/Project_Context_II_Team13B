using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseChairman : MonoBehaviour
{
    void AssignChairman(List<Player> players)
    {
        int chairmanIndex = Random.Range(0, players.Count);
        players[chairmanIndex].isChairman = true;
    }

    void UnassignChairman(List<Player> players)
    {
        for(int i = 0; i < players.Count; i++)
        {
            if(players[i].isChairman)
            {
                players[i].isChairman = false;
                break;
            }
        }
    }
}
