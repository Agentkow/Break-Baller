using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private ParticleSystem explosion;
    private AudioSource enemyDeathSounds;
    private GameManager manager;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyDeathSounds = GetComponent<AudioSource>();
        explosion = GetComponent<ParticleSystem>();
        StartCoroutine(DestroyExplosion());
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void Update()
    {
        enemyDeathSounds.pitch = 0.6f+(0.1f*(manager.multiplier-1));
    }
    IEnumerator DestroyExplosion()
    {
        yield return new WaitForSeconds(explosion.main.duration);
        Destroy(gameObject);
    }
}
