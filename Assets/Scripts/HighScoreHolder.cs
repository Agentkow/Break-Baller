using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreHolder : MonoBehaviour
{
    public float highScore;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void SaveScore()
    {
        SaveSystem.SaveScore(this);
    }

    public void LoadScore()
    {
        Score scoreData = SaveSystem.ScoreLoad();

        highScore = scoreData.savedScore;
    }
}
