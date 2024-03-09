using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform followPoint;
    [SerializeField] Transform viewPoint;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,
            followPoint.position,
            Time.deltaTime * (Vector3.Distance(transform.position, followPoint.position) * 1.5f));
        transform.LookAt(viewPoint.position);
    }


}
