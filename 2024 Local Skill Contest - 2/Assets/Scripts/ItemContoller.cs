using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContoller : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0f, 1, 0f));
    }
}
