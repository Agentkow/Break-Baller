﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByBall : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private AudioSource hitSound;

    [SerializeField]
    private float minRandom;
    [SerializeField]
    private float maxRandom;

    void OnCollisionEnter(Collision collision)
    {
        hitSound.pitch = Random.Range(minRandom, maxRandom);
        hitSound.Play();
    }
}
