using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public NavMeshAgent agent;

    public bool isChairman = false;
    private string charName;
    public TMP_Text text;
    public int score = 0;

    private void Start()
    {
        charName = text.text;
        SetChairman("Chariman");
        agent = this.GetComponent<NavMeshAgent>();
    }

    public void SetChairman(string chairman)
    {
        if(isChairman)
        {
            text.text = charName + " " + chairman;
        }
        else
        {
            text.text = charName;
        }
    }

    public void SetDestinationForAgent(Vector3 target)
    {
        agent.updatePosition = false;
        agent.SetDestination(target);
        agent.updatePosition = true;
    }
}
