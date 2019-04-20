using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public NavMeshAgent agent;

    public bool isChairman = false;
    public int score = 0;

    public GameObject chair;

    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(isChairman)
        {
            chair.SetActive(true);
        }
        else
        {
            chair.SetActive(false);
        }
    }

    public void SetChairman()
    {
        isChairman = true;
        chair.SetActive(true);
    }

    public void UnsetChairman()
    {
        isChairman = false;
        chair.SetActive(false);
    }

    public void SetDestinationForAgent(Vector3 target)
    {
        agent.updatePosition = false;
        agent.SetDestination(target);
        agent.updatePosition = true;
    }
}
