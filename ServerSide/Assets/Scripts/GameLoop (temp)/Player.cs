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

    public void SetChairman()
    {
        isChairman = true;
        chair.SetActive(isChairman);
    }

    public void UnsetChairman()
    {
        isChairman = false;
        chair.SetActive(isChairman);
    }

    public void SetDestinationForAgent(Vector3 target)
    {
        agent.updatePosition = false;
        agent.SetDestination(target);
        agent.updatePosition = true;
    }
}
