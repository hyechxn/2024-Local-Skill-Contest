using UnityEngine;

public class CollisionF : Collision
{
    private void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (CompareTag("Player"))
        {
            if (other.transform.CompareTag("Enemy"))
            {
                rigid.AddForce(-transform.forward * 5 * Time.deltaTime, ForceMode.Impulse);
            }
        }
        else if (CompareTag("Enemy"))
        {
            if (other.transform.CompareTag("Player"))
            {
                rigid.AddForce(-transform.forward * 5 *Time.deltaTime, ForceMode.Impulse);
            }
        }
    }
}
