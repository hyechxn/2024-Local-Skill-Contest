using Unity.AI.Navigation.Samples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Car : MonoBehaviour
{

    public float speed;
    public float accel;
    public float rotateSpeed;

    public float originSpeed;
    public float originAccel;

    public Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();

        originSpeed = speed;
        originAccel = accel;
    }


    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            if (StageController.instance.goalIn[0] == "")
                StageController.instance.goalIn[0] = gameObject.tag;
            else
                StageController.instance.goalIn[1] = gameObject.tag;

            if (tag == "Player")
                StageController.instance.result.SetActive(true);
        }
    }

    protected void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Road"))
        {
            if (GameManager.Instance.inventory[4])
            {

                speed = originSpeed * 1.75f;
                accel = originAccel * 1.6f;
            }
            else if (GameManager.Instance.inventory[3])
            {
                speed = originSpeed * 1.3f;
                accel = originAccel * 1.25f;
            }
            else
            {
                speed = originSpeed;
                accel = originAccel;
            }
        }
    }

    protected void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Road"))
        {
            if (!
            ((StageController.instance.curStage == StageController.Map.Desert && GameManager.Instance.inventory[0]) ||
            (StageController.instance.curStage == StageController.Map.Mountain && GameManager.Instance.inventory[1]) ||
            (StageController.instance.curStage == StageController.Map.City && GameManager.Instance.inventory[2]))
           )
            {
                speed = speed * 0.75f;
                accel = accel * 0.8f;
            }

            else
            {
                speed = speed * 1;
                accel = accel * 1;
                
            }
        }
    }
}