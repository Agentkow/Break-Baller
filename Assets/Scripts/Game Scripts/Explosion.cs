using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private ParticleSystem explosion;
    private AudioSource enemyDeathSounds;

    // Start is called before the first frame update
    void Start()
    {
        enemyDeathSounds = GetComponent<AudioSource>();
        explosion = GetComponent<ParticleSystem>();
        StartCoroutine(DestroyExplosion());
    }
    
    IEnumerator DestroyExplosion()
    {
        yield return new WaitForSeconds(explosion.main.duration);
        Destroy(gameObject);
    }
}
