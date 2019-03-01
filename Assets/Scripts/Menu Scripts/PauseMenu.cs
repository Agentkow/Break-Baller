using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
#pragma warning disable 0649
    public static bool gamePause = false;

    [SerializeField]
    private float timeSpeed = 4f;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private AudioSource gameMusic;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            if (gamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = timeSpeed;
        gameMusic.Play();
        gamePause = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        gameMusic.Pause();
        Time.timeScale = 0f;
        gamePause = true;
    }
}
