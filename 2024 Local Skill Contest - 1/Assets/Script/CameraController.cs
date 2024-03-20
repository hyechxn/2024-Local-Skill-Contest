using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum cameraType
    {
        playerCamera,
        Minimap
    }

    cameraType type;

    [SerializeField] Transform followPoint;
    [SerializeField] Transform viewPoint;
    void FixedUpdate()
    {
        if (type == cameraType.playerCamera)
        {
            transform.position = Vector3.Lerp(transform.position,
                followPoint.position,
                Time.deltaTime * (Vector3.Distance(transform.position, followPoint.position) * 1.25f));
            transform.LookAt(viewPoint.position);
        }
        else
        {
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }


}
