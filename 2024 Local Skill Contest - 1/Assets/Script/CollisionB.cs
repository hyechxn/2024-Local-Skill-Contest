using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionB : Collision
{
    private void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (CompareTag("Player"))
        {
            if (other.transform.CompareTag("Enemy"))
            {
                rigid.AddForce(transform.forward * 30 * Time.deltaTime, ForceMode.Impulse);
            }
        }
        else if (CompareTag("Enemy"))
        {
            if (other.transform.CompareTag("Player"))
            {
                rigid.AddForce(transform.forward * 20 * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }
}
