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
    public void Awake()
    {
        originAccel = accel;
        originSpeed = speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            //StageController.instance.
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
            accel /= 2;
            speed = 10;
        }
    }
}
