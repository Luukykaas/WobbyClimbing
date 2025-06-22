using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlugNav : MonoBehaviour
{
    public GameObject Player;
    public NavMeshAgent agent;
    void Update()
    {
        //transform.LookAt(Player.transform.position);
        agent.SetDestination(Player.transform.position);
    }
}
