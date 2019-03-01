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
    private int ChangeFontSize = 23;

    public float health = 10;
    public float score;
    public bool pointGain;
    public bool healthLose;
    
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

    [SerializeField]
    private Text gameOver;

    [SerializeField]
    private Text multiplierText;

    public float multiplier = 1;



    // Start is called before the first frame update
    void Start()
    {
        ballLives = 10;
    }

    private void Awake()
    {
        gameOver.text = "";
    }

    void FixedUpdate()
    {
        scoreText.text = score.ToString(); ;
        ballCountText.text = "BALL " + ballLives;
        healthText.text = "HEALTH " + health;
        ballCountText.color = Color.white;
        healthText.color = Color.white;
        multiplierText.text = "X" + multiplier;

        if (pointGain)
        {
            scoreText.fontSize = ChangeFontSize;
            StartCoroutine(PointJump());
        }
        else
        {
            scoreText.fontSize = initialFontSize;
        }

        if (healthLose)
        {
            healthText.fontSize = ChangeFontSize;
            StartCoroutine(HealthLose());
        }
        else
        {
            healthText.fontSize = initialFontSize;
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
            Instantiate(ballPrefab, ballSpawnPosition.position, ballPrefab.gameObject.transform.rotation);
            ballLives--;
        }

        if (health <= 1)
        {
            healthText.color = Color.red;
        }

        if (ballLives <= 3)
        {
            ballCountText.color = Color.red;
        }

        if (health <= 0 || ballLives <= 0)
        {
            gameOver.text = "GAME OVER";
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator PointJump()
    {
        yield return new WaitForSeconds(0.3f);
        pointGain = false;
    }

    IEnumerator HealthLose()
    {
        yield return new WaitForSeconds(0.3f);
        healthLose = false;
    }

}
