using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Car
{
    public NavMeshAgent agent;

    public Transform goal;
    public void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        Debug.Log(agent.enabled);
        agent.destination = goal.position;

        GameManager.Instance.enemy = transform;
        GameManager.Instance.enemyLogic = this;

        originAccel = accel;
        originSpeed = speed;

        agent.speed = speed;
        agent.acceleration = accel;
        agent.angularSpeed = rotateSpeed;

    }

    private new void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.tag == "Item")
        {
            Destroy(other.gameObject);
        }
    }
}