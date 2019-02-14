using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private GameManager manager;

    [SerializeField]
    private float points = 100f;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ball"))
    //    {
    //        manager.score += points;
    //    }
        
    //}
    private void OnDestroy()
    {
        manager.score += points;
    }
}
