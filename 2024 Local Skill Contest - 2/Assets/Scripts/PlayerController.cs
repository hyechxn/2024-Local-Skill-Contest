using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Car
{

    public LayerMask layer;
    private void OnEnable()
    {
        GameManager.Instance.player = transform;
        GameManager.Instance.playerLogic = this;
    }

    private void Update()
    {
        Move();
        Rot();
    }

    private void LateUpdate()
    {
        //transform.LookAt(transform.forward);
        
    }


    void Move()
    {
        if (Physics.Raycast(transform.position, -transform.up, 1.5f, layer))
        {
            Debug.Log("123");
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rigid.AddForce(transform.right * speed * Time.deltaTime, ForceMode.Acceleration);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                rigid.AddForce(-transform.right * 0.75f * speed * Time.deltaTime, ForceMode.Acceleration);
            }
        }
        rigid.velocity = new Vector3(Mathf.Clamp(rigid.velocity.x, -accel, accel), rigid.velocity.y, Mathf.Clamp(rigid.velocity.z, -accel, accel));
    }

    void Rot()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, new Vector3(0, -1.5f, 0));
    }

}