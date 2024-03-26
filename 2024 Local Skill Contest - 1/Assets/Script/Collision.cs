using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    protected Rigidbody rigid;
    private void Start()
    {
        rigid = transform.parent.GetComponent<Rigidbody>();
    }
}
