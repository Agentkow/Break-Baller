using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    private float force = 1000f;
    private float forceRadius = 1.0f;


    void OnCollisionEnter(Collision collision)
    {
        foreach(Collider col in Physics.OverlapSphere(transform.position, forceRadius))
        {
            if (col.GetComponent<Rigidbody>())
            {
                col.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, forceRadius);
            }
        }
    }

}
