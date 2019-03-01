using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private float force = 10000f;
    [SerializeField]
    private float forceRadius = 3f;
    
    void OnCollisionEnter(Collision collision)
    {
        foreach (Collider col in Physics.OverlapSphere(transform.position, forceRadius))
        {
            if (collision.rigidbody)
            {
                collision.rigidbody.AddExplosionForce(force, transform.position, forceRadius);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, forceRadius);
    }

}
