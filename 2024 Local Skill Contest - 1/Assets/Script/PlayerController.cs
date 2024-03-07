using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("참조")]
    [SerializeField] Rigidbody rigid;
    [SerializeField] PhysicMaterial carPhysic;

    [Space(10)]
    [Header("속성")]
    [SerializeField] float carSpeed;
    [SerializeField] float maxVelocity;

    [SerializeField] float rotSpeed;
    private bool isMoving;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //Forward Move
        if (Input.GetKey(KeyCode.UpArrow))
        {
            isMoving = true;

            rigid.AddForce(transform.forward * carSpeed, ForceMode.Acceleration);
            if (Mathf.Abs(rigid.velocity.x) > maxVelocity)
                rigid.velocity = new Vector3(Mathf.Sign(rigid.velocity.x) * maxVelocity, rigid.velocity.y, rigid.velocity.z);
            if (Mathf.Abs(rigid.velocity.z) > maxVelocity)
                rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, Mathf.Sign(rigid.velocity.z) * maxVelocity);
        }
        //Backward Move
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            isMoving = true;

            rigid.AddForce(-transform.forward * carSpeed, ForceMode.Acceleration);
        }
        //Non Move
        else
        {
            isMoving = false;
        }

        //Rotation
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(0f, -rotSpeed, 0f);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(0f, rotSpeed, 0f);

        //Break
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rigid.velocity = new Vector3(Mathf.Lerp(rigid.velocity.x, 0, 0.025f), 0f, Mathf.Lerp(rigid.velocity.z, 0, 0.0025f));
        }

        //Add Gravity
        rigid.AddForce(Vector3.down * 9.8f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }
}
