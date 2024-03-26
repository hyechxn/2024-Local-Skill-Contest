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
        agent.updateRotation = false;
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
        Vector2 forward = new Vector2(transform.position.z, transform.position.x);
        Vector2 steeringTarget = new Vector2(agent.steeringTarget.z, agent.steeringTarget.x);

        //������ ���� ��, ���Լ��� ���� ���Ѵ�.
        Vector2 dir = steeringTarget - forward;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //���� ����
        transform.eulerAngles = Vector3.up * angle;
        if (agent.enabled)
            if (enemyType == Enumtype.enemy)
            {

                if (agent.remainingDistance <= 0.5f)
                {
                    agent.speed = 0;
                    agent.acceleration = 0;
                    agent.angularSpeed = 0;
                    agent.enabled = false;
                }

            }
    }
    protected new void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            if (StageController.instance.goalIn[0] == "")
                StageController.instance.goalIn[0] = gameObject.tag;
            else
                StageController.instance.goalIn[1] = gameObject.tag;

            isGoal = true;
            rotateSpeed = 0;
            speed = 0;
            accel = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Tunnel"))
        {
            if (enemyType == Enumtype.nonEnemy)
                Destroy(gameObject);
        }
    }
}
