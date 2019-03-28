using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseChairman : MonoBehaviour
{
    int chairmanIndex;

    public void AssignChairman(List<Player> players)
    {
        UnassignChairman(players);

        if(chairmanIndex < players.Count - 1)
        {
            chairmanIndex++;
        }
        else
        {
            chairmanIndex = 0;
        }

        Debug.Log(chairmanIndex);
        Debug.Log(players[chairmanIndex].name);

        if(!players[chairmanIndex].isChairman)
        {
            players[chairmanIndex].SetChairman();
        }
    }

    //private int RandomIndex(int listSize, int prevIndex)
    //{
    //    int chairmanIndex = Random.Range(0, listSize);
    //    if(chairmanIndex != previousIndex)
    //    {
    //        return chairmanIndex;
    //    }
    //    return Random.Range(0, listSize);
    //}

    public void UnassignChairman(List<Player> players)
    {
        for(int i = 0; i < players.Count; i++)
        {
            if(players[i].isChairman)
            {
                players[i].UnsetChairman();
                break;
            }
        }
    }
}
