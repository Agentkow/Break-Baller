using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
#pragma warning disable 0168 
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float ranMin;
    [SerializeField]
    private float ranMax;

    private GameManager manager;

    [SerializeField]
    private float setTime= 10;

    [SerializeField]
    private float timer = 10;
    
    
    // Update is called once per frame
    void Update()
    {

        if (timer<=0)
        {
            timer = setTime;
            Instantiate(enemy, new Vector3(transform.position.x + Random.Range(ranMin,ranMax), transform.position.y, transform.position.z), transform.rotation);
        }
        else
        {
            timer -= 0.1f;
        }
        
    }
}
