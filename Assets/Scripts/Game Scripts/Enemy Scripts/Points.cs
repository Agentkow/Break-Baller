using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private GameManager manager;

    [SerializeField]
    private float points = 100f;

    private bool ballHit = false;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ballHit = true;
        }
    }

    private void OnDestroy()
    {
        if (ballHit)
        {
            manager.score += points* manager.multiplier;
            manager.pointGain = true;
        }
        
    }
}
