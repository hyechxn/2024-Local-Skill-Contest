using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Car
{

    public ParticleSystem p1;

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


    void Move()
    {
        if (Physics.Raycast(transform.position, -transform.up, 1.5f, layer))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (!p1.isPlaying)
                    p1.Play();
                rigid.AddForce(transform.right * speed * Time.deltaTime, ForceMode.Acceleration);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (!p1.isPlaying)
                    p1.Play();
                rigid.AddForce(-transform.right * 0.75f * speed * Time.deltaTime, ForceMode.Acceleration);
            }
            else
            {
                p1.Stop();
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


    IEnumerator Booster(float speed)
    {
        originAccel *= speed;
        originSpeed *= speed;
        yield return new WaitForSeconds(2.5f);
        originAccel /= speed;
        originSpeed /= speed;

    }

    private new void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.tag == "Item")
        {
            Debug.Log(123);
            int itemIdx = Random.Range(1, 7);
            Debug.Log(itemIdx);
            switch (itemIdx)
            {
                case 1:
                    StartCoroutine(StageController.instance.ItemText("소형 부스터!!"));
                    StartCoroutine(Booster(1.275f));
                    break;
                case 2:
                    StartCoroutine(StageController.instance.ItemText("부스터!!"));
                    StartCoroutine(Booster(1.45f));
                    break;
                case 3:
                    StartCoroutine(StageController.instance.Gain(100));
                    break;
                case 4:
                    StartCoroutine(StageController.instance.Gain(500));
                    break;
                case 5:
                    StartCoroutine(StageController.instance.Gain(1000));
                    break;
                case 6:
                    StageController.instance.ShopGo();
                    break;
            }
            Destroy(other.gameObject);
        }
    }
}