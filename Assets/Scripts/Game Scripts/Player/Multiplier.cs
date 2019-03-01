using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Game Manager"))
        {
            manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            manager.multiplier++;
        }
        if (collision.gameObject.CompareTag("Flipper"))
        {
            manager.multiplier = 1;
        }
    }
}
