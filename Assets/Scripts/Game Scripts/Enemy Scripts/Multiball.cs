using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiball : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    void OnDestroy()
    {
        Instantiate(ball, transform.position, transform.rotation);
    }
}
