using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    void Update()
    { 
        transform.localPosition = target.position + new Vector3(0f, 3.7f, -6f);
        transform.rotation = Quaternion.Euler(25f, transform.rotation.eulerAngles.y + target.rotation.eulerAngles.y, 0f);
    }

    
}
