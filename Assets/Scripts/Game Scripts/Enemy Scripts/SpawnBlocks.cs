using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    [SerializeField]
    private GameObject block;

    void OnDestroy()
    {
        Instantiate(block, transform.position, transform.rotation);
    }
}
