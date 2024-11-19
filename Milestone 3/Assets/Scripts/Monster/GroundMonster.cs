using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroundMonster : Monster
{
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        Move();
    }

    public override void Move()
    {
        agent.SetDestination(GameObject.Find("PlayerBase").transform.position);
    }
}
