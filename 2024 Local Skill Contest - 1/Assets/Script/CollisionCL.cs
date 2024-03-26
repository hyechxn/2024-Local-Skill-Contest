using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCL : Collision
{
    private void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (CompareTag("Player"))
        {
            if (other.transform.CompareTag("Enemy"))
            {
                rigid.AddForce(transform.right * 10 * Time.deltaTime, ForceMode.Impulse);
            }
        }
        else if (CompareTag("Enemy"))
        {
            if (other.transform.CompareTag("Player"))
            {
                rigid.AddForce(transform.right * 10 * Time.deltaTime, ForceMode.Impulse);
                
            }
        }
    }
}
