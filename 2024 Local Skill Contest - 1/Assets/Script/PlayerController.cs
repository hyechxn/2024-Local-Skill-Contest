using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class PlayerController : Car
{
    [Header("참조")]
    [SerializeField] Rigidbody rigid;
    [SerializeField] PhysicMaterial carPhysic;

    [Space(5)]
    [Header("속성")]
    [SerializeField] float rotSpeed;

    new void Awake()
    {
        base.Awake();
        GameManager.Instance.playerCar = transform;
        GameManager.Instance.playerLogic = GetComponent<PlayerController>();
        
        rigid = GetComponent<Rigidbody>();
        rigid.centerOfMass = new Vector3(0f, -0.3f, 1f);
    }


    void Update()
    {
        Move();
        Rot();
    }

    void Move()
    {
        if (Physics.Raycast(transform.position +new Vector3(0, 0.25f, 0f), -transform.up, 1.25f, LayerMask.GetMask("Ground")))
        {
            //Forward Move
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rigid.AddForce(transform.forward * speed, ForceMode.Acceleration);
                if (Mathf.Abs(rigid.velocity.x) > accel)
                    rigid.velocity = new Vector3(Mathf.Sign(rigid.velocity.x) * accel, rigid.velocity.y, rigid.velocity.z);
                if (Mathf.Abs(rigid.velocity.z) > accel)
                    rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, Mathf.Sign(rigid.velocity.z) * accel);
            }
            //Backward Move
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rigid.AddForce(-transform.forward * speed, ForceMode.Acceleration);
            }

            //Rotation
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(0f, -rotSpeed, 0f);
            else if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(0f, rotSpeed, 0f);

            //Break
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rigid.velocity = new Vector3(Mathf.Lerp(rigid.velocity.x, 0, 0.025f), 0f, Mathf.Lerp(rigid.velocity.z, 0, 0.0025f * Time.deltaTime));
            }
        }
    }
    void Rot()
    {
        if (Mathf.Abs(transform.rotation.eulerAngles.x) > 169 || Mathf.Abs(transform.rotation.eulerAngles.z) > 169)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                transform.rotation = Quaternion.Euler(new Vector3(0f, transform.rotation.eulerAngles.y, 0f));
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, new Vector3(0f, -0.5f, 0f));
    }
}
