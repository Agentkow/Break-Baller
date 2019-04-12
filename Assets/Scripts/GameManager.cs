using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
#pragma warning disable 0649
    public float ballLives = 10;

    [SerializeField]
    private int initialFontSize = 24;
    private int ChangeFontSize;

    public float health = 10;
    public float score;
    public bool pointGain;
    public bool healthLose;
    
    [SerializeField]
    private Transform ballSpawnPosition;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private TextMeshProUGUI ballCountText;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI healthText;

    [SerializeField]
    private TextMeshProUGUI gameOver;

    [SerializeField]
    private TextMeshProUGUI multiplierText;

    [SerializeField]
    private AudioSource music;

    [SerializeField]
    private AudioSource gameOverMusic;
    
    public float multiplier = 1;

    public bool gameOn = true;

    Color normalColor = new Color(255f, 243f, 209f);

    // Start is called before the first frame update
    void Start()
    {
        ballLives = 10;
    }

    private void Awake()
    {
        gameOn = true;
        gameOver.text = "";
        ChangeFontSize = initialFontSize + 1;
    }

    void FixedUpdate()
    {
        scoreText.text = score.ToString("00000000"); ;
        ballCountText.text = "BALL " + ballLives;
        healthText.text = "HEALTH " + health;
        ballCountText.color = normalColor;
        healthText.color = normalColor;
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

        if (health <= 0 || ballLives <= 0)
        {
            gameOver.text = "GAME OVER";
            music.Stop();
            gameOn = false;
            if (score > PlayerPrefs.GetFloat("High Score", 0))
            {
                PlayerPrefs.SetFloat("High Score", score);
            }
            StartCoroutine(EndGame());
        }
    }

    // Update is called once per frame
    void Update()
    {
        LivesAndHealth();
        

    }

    private void LivesAndHealth()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length <= 0 && gameOn)
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

        
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(gameOverMusic.clip.length);
        
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
