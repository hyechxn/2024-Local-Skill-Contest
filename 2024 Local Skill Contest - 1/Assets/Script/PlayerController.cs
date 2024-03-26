using System.Collections;
using UnityEngine;

public class PlayerController : Car
{
    [Header("참조")]
    [SerializeField] public Rigidbody rigid;
    [SerializeField] PhysicMaterial carPhysic;

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
        if (!isGoal)
        {
            Move();
            Rot();
        }
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
                transform.Rotate(0f, -rotateSpeed, 0f);
            else if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(0f, rotateSpeed, 0f);

            transform.LookAt(transform.position, transform.forward);
            
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


    private new void OnTriggerEnter(Collider other)
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

        if (other.CompareTag("Item"))
        {
            int itemNum = Random.Range(0, 6);
            Debug.Log(itemNum);
            StageController.instance.itemCount++;
            switch (itemNum)
            {
                case 0:
                    GameManager.Instance.money += 1000;
                    StartCoroutine(StageController.instance.SetGain(1000));
                    break;
                case 1:
                    GameManager.Instance.money += 500;
                    StartCoroutine(StageController.instance.SetGain(500));
                    break;
                case 2:
                    GameManager.Instance.money += 100;
                    StartCoroutine(StageController.instance.SetGain(100));
                    break;
                case 3:
                    StartCoroutine(SpeedUp(1.3f));
                    StartCoroutine(StageController.instance.SetText("소형 부스터!"));
                    break;
                case 4:
                    StartCoroutine(SpeedUp(2));
                    StartCoroutine(StageController.instance.SetText("대형 부스터!"));
                    break;
                case 5:
                    StageController.instance.shopPage.SetActive(true);
                    break;
            }
            Destroy(other.gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * 5);
    }

    public IEnumerator SpeedUp(float n)
    {
        originAccel *= n;
        originSpeed *= n;
        yield return new WaitForSeconds(2.5f);
        originAccel /= n;
        originSpeed /= n;
    }
}
