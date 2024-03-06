using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigid;

    [SerializeField] PhysicMaterial carPhysic;

    [SerializeField] float carSpeed;
    private bool isMoving;
    private bool isFMoving;
    private bool isBMoving;

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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            isBMoving = false;
            isFMoving = true;
            isMoving = true;

            rigid.AddForce(transform.forward * carSpeed * 0.2f, ForceMode.Acceleration);
            if (Mathf.Abs(rigid.velocity.x) > 10f)
                rigid.velocity = new Vector3(Mathf.Sign(rigid.velocity.x) * 10, rigid.velocity.y, rigid.velocity.z);
            if (Mathf.Abs(rigid.velocity.z) > 10f)
                rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, Mathf.Sign(rigid.velocity.z) * 10);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            isFMoving = false;
            isBMoving = true;
            isMoving = true;

            rigid.AddForce(-transform.forward * carSpeed * 0.2f, ForceMode.Acceleration);
        }
        else
        {
            isFMoving = false;
            isBMoving = false;
            isMoving = false;
        }

        if (isMoving)
        {
            if (isFMoving)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                        transform.rotation.eulerAngles.y - 0.5f,
                        transform.rotation.eulerAngles.z);
                else if (Input.GetKey(KeyCode.RightArrow))
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                        transform.rotation.eulerAngles.y + 0.5f,
                        transform.rotation.eulerAngles.z);
            }

            if (isBMoving)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                        transform.rotation.eulerAngles.y + 0.5f,
                        transform.rotation.eulerAngles.z);
                else if (Input.GetKey(KeyCode.RightArrow))
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                        transform.rotation.eulerAngles.y - 0.5f,
                        transform.rotation.eulerAngles.z);
            }


            if (Input.GetKey(KeyCode.LeftShift))
            {
                rigid.velocity = new Vector3(Mathf.Lerp(rigid.velocity.x, 0, 0.0025f), 0f, Mathf.Lerp(rigid.velocity.z, 0, 0.0025f));
            }


        }
        rigid.AddForce(Vector3.down * 9.8f);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }
}
