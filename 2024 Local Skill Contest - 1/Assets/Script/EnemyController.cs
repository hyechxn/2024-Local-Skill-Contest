using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Car
{
    public enum Enumtype
    {
        enemy,
        nonEnemy
    }
    public Enumtype enemyType;

    public Transform goal;
    public NavMeshAgent agent;

    private void OnDisable()
    {
        agent.speed = 0;
        agent.acceleration = 0;
    }

    private void OnEnable()
    {
        agent.speed = speed;
        agent.acceleration = accel;
    }


    new void Awake()
    {
        base.Awake();
        if (enemyType == Enumtype.enemy)
        {
            GameManager.Instance.enemyCar = transform;
            GameManager.Instance.enemyLogic = GetComponent<EnemyController>();

        }
        if (enemyType == Enumtype.nonEnemy)
        {
            goal = GameObject.Find("TunnelPoint").transform;
        }
        agent.SetDestination(goal.position);
    }
    private void Update()
    {
        if (agent.enabled)
            if (enemyType == Enumtype.enemy)
            {
                if (agent.remainingDistance <= 0.5f)
                {
                    agent.speed = 0;
                    agent.acceleration = 0;
                    agent.angularSpeed = 0;
                    agent.enabled = false;
                    Debug.Log(123);
                }

            }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Tunnel"))
        {
            Destroy(gameObject);
        }
    }
}
