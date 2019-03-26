using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseChairman : MonoBehaviour
{
    int previousIndex;

    public void AssignChairman(List<Player> players)
    {
        int chairmanIndex = RandomIndex(players.Count, previousIndex);
        previousIndex = chairmanIndex;

        if(!players[chairmanIndex].isChairman)
        {
            players[chairmanIndex].isChairman = true;
        }
    }

    public int RandomIndex(int listSize, int prevIndex)
    {
        int chairmanIndex = Random.Range(0, listSize);
        if(chairmanIndex != previousIndex)
        {
            return chairmanIndex;
        }
        return Random.Range(0, listSize);
    }

    public void UnassignChairman(List<Player> players)
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
