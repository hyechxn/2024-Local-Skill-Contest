using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    protected float originSpeed;
    [SerializeField]
    protected float accel;
    protected float originAccel;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            if (StageController.instance.goalIn[0] == "" )
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
            accel = accel * 0.5f;
            speed = 20;
        }
    }
}
