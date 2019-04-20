using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseChairman : MonoBehaviour
{
    int chairmanIndex;
    int prevChairmanIndex;

    public void AssignChairman(List<Player> players)
    {
        UnassignChairman(players);
        //prevChairmanIndex = chairmanIndex;
        if(chairmanIndex < players.Count - 1)
        {
            chairmanIndex++;
            players[chairmanIndex].isChairman = true;
            //players[prevChairmanIndex].isChairman = false;
        }
        else
        {
            chairmanIndex = 0;
        }

        Debug.Log(chairmanIndex);
        Debug.Log(players[chairmanIndex].name);
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
                players[i].isChairman = false;
            }
        }
    }
}
