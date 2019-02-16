using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private GameManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            manager.health--;
            Destroy(other.gameObject);
        }
    }
}
