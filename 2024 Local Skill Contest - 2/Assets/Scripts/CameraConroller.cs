using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform lookPoint;

    private void FixedUpdate()
    {
        transform.LookAt(lookPoint);
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 4.5f);
    }
}