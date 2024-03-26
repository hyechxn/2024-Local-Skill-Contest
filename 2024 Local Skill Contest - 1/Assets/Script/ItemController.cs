using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemController : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 10f, 0f) * Time.deltaTime * 20);
    }
    
}
