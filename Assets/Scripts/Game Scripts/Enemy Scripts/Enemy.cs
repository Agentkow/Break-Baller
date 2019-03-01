using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
#pragma warning disable 0649
    private float health = 1;
    
    private GameManager manager;
    
    private GameObject heartPos;
    
    [SerializeField]
    private float speed = 2;

    [SerializeField]
    private float damage= 2;

    private CameraShake shake;

    [SerializeField]
    private GameObject explosion;

    

    void Start()
    {
        shake = GameObject.Find("Camera Shake Control").GetComponent<CameraShake>();
        heartPos = GameObject.Find("Heart");
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            health -= damage;
        }

        if (collision.gameObject.CompareTag("Dead Zone"))
        {
            shake.hurt = true;
            manager.health--;
            manager.healthLose = true;
            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
        shake.trigger = true;
        
    }
}
