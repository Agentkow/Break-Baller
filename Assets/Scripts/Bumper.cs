using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField]
    private float force = 10000f;
    [SerializeField]
    private float forceRadius = 1.0f;

    private Rigidbody ball;
    
    void OnCollisionEnter(Collision collision)
    {
        ball = collision.rigidbody;
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Bumper Hit");
            ball.AddForce(transform.position - ball.position, ForceMode.Impulse);
        }
    }

}
