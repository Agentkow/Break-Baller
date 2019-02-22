using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
#pragma warning disable 0649
    private float ballLives = 10;
    private int initialFontSize = 22;
    [SerializeField]
    private int pointGainFontSize = 23;

    public float health = 10;
    public float score;
    public bool pointGain;
    
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
        scoreText.text = score.ToString(); ;
        ballCountText.text = "BALL " + ballLives;
        healthText.text = "HEALTH " + health;
        ballCountText.color = Color.white;
        healthText.color = Color.white;

        if (pointGain)
        {
            scoreText.fontSize = pointGainFontSize;
            StartCoroutine(pointJump());
        }
        else
        {
            scoreText.fontSize = initialFontSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
        LivesAndHealth();

        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("Main Menu");
        }

    }

    private void LivesAndHealth()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length <= 0 && ballLives != 0)
        {
            ballLives--;
            Instantiate(ballPrefab, ballSpawnPosition.position, ballPrefab.gameObject.transform.rotation);
        }

        if (health <= 3)
        {
            healthText.color = Color.red;
        }

        if (ballLives <= 3)
        {
            ballCountText.color = Color.red;
        }

        if (health <= 0 || ballLives <= 0)
        {
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator pointJump()
    {
        yield return new WaitForSeconds(0.3f);
        pointGain = false;
    }

}
