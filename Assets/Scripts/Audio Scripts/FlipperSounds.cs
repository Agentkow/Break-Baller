using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperSounds : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private string inputName;

    private AudioSource flipperSound;

    // Start is called before the first frame update
    void Start()
    {
        flipperSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(inputName))
        {
            flipperSound.Play();
        }
    }
}
