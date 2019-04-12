using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
#pragma warning disable 0649
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

    [SerializeField]
    private float timeMin;

    [SerializeField]
    private float timeMax;

    // Update is called once per frame
    void FixedUpdate()
    {
        setTime = setTime+Random.Range(timeMin,timeMax);
        if (timer<=0)
        {
            timer = setTime;
            Instantiate(enemy, new Vector3(transform.position.x + Random.Range(ranMin,ranMax), transform.position.y, transform.position.z), transform.rotation);
        }
        else
        {
            timer -= 1f *Time.deltaTime;
        }
        
    }
}
