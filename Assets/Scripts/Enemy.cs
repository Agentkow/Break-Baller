using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health = 1;
    
    private GameManager manager;
    
    private GameObject heartPos;
    
    [SerializeField]
    private float speed = 2;

    [SerializeField]
    private float damage= 2;

    void Start()
    {
        heartPos = GameObject.Find("Heart");
    }
    
    private void Update()
    {
        transform.LookAt(heartPos.transform);
        transform.Translate(Vector3.forward*(speed* Random.Range(1, 5)) *Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            health -= damage;
        }
    }
}
