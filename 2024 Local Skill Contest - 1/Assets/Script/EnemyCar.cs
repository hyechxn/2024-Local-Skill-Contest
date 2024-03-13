using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCar : MonoBehaviour
{
    public Transform goal;
    NavMeshAgent agent;
    public Transform qpal;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
    private void Update()
    {
        //transform.LookAt(agent.nextPosition);
        //qpal.position = (agent.nextPosition);
    }
}
