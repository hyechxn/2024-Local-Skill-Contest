using Unity.VisualScripting;
using UnityEngine;

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


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Road"))
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (
            (StageController.instance.curStage == StageController.Map.Desert && GameManager.Instance.inventory[0]) ||
            (StageController.instance.curStage == StageController.Map.Mountain && GameManager.Instance.inventory[1]) ||
            (StageController.instance.curStage == StageController.Map.City && GameManager.Instance.inventory[2])
           )
        {
            if (other.CompareTag("Road"))
            {
                speed = speed * 0.75f;
                accel = speed * 0.8f;
            }
        }
    }
}