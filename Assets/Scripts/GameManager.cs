﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
#pragma warning disable 0168
    private float ballLives = 10;

    public float health = 10;

    public float score;
    
    [SerializeField]
    private Transform ballSpawnPosition;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private Text ballCountText;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        ballLives = 10;
    }

    void FixedUpdate()
    {
        scoreText.text = "Score: " + score;
        ballCountText.text = "BALL " + ballLives;
        healthText.text = "Health " + health;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectsWithTag("Ball").Length <= 0 && ballLives!=0)
        {
            ballLives--;
            Instantiate(ballPrefab, ballSpawnPosition.position, ballPrefab.gameObject.transform.rotation);
        }



        if (health<=0 || ballLives <=0)
        {
            StartCoroutine(EndGame());
        }

        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("Main Menu");
        }

    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Main Menu");
    }


}
