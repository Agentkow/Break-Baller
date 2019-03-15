using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameManager manager;

    [SerializeField]
    private AudioSource gameOverSound;

    [SerializeField]
    private AudioSource ballLossAudio;

    [SerializeField]
    private AudioSource tikiLossAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballLossAudio.Play();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            manager.health--;
            tikiLossAudio.Play();
            Destroy(other.gameObject);
        }

        if (manager.health == 0 || manager.ballLives == 0)
        {
            gameOverSound.Play();
        }
    }
}
