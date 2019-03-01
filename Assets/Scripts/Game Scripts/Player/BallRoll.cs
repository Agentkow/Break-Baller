using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRoll : MonoBehaviour
{
    private float highSpeeds;
    private float nomSpeed = 100f;
    
    private Rigidbody rb;
    private Vector3 vel;
    [SerializeField]
    private float mag;

    [SerializeField]
    private AudioSource fastRollSound;
    [SerializeField]
    private AudioSource mildRollSound;
    [SerializeField]
    private AudioSource slowRollSound;
    [SerializeField]
    private AudioSource currentAudio;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentAudio = slowRollSound;
        currentAudio.loop = true;
        currentAudio.Play();
    }

    private void Update()
    {
        MoveSound();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       
        
    }

    void MoveSound()
    {
        currentAudio.pitch = rb.velocity.magnitude/nomSpeed;
    }
}
