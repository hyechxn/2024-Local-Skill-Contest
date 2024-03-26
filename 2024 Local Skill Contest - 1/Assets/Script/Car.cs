using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public float originSpeed;
    [SerializeField]
    public float accel;
    public float originAccel;
    [SerializeField]
    protected float rotateSpeed;
    protected float originRotateSpeed;

    public bool isGoal;
    public void Awake()
    {
        originAccel = accel;
        originSpeed = speed;
        originRotateSpeed = rotateSpeed;
    }
    protected void OnTriggerEnter(Collider other)
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

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Road")
        {
            accel = originAccel;
            speed = originSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Road")
        {
            if (StageController.instance.map == StageController.Map.Desert && GameManager.Instance.inventoty[0])
            {
                accel = originAccel;
                speed = originSpeed;
            }
            else if (StageController.instance.map == StageController.Map.Mountain && GameManager.Instance.inventoty[1])
            {
                accel = originAccel;
                speed = originSpeed;

            }
            else if (StageController.instance.map == StageController.Map.City && GameManager.Instance.inventoty[2])
            {
                accel = originAccel;
                speed = originSpeed;

            }
            else
            {
                accel *= 0.5f;
                speed *= 0.5f;
            }
        }
    }
}
