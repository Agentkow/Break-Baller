using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    [SerializeField]
    private float timer = 100;
    
    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            Destroy(this);
        }
        else
        {
            timer -= 1f;
        }
    }
}
