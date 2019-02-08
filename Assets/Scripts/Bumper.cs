using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField]
    private float force = 10000f;
    [SerializeField]
    private float forceRadius = 3f;

    [SerializeField]
    private GameManager manager;

    [SerializeField]
    private float points = 100f;

    private Rigidbody ball;

   

    void OnCollisionEnter(Collision collision)
    {
      
        foreach (Collider col in Physics.OverlapSphere(transform.position, forceRadius))
        {
            
            if (collision.rigidbody)
            {
                Debug.Log("Hit");
                manager.score += points;
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
