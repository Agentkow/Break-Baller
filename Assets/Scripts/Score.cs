﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Score
{
    public float savedScore;

    public Score (HighScoreHolder highScore)
    {
        savedScore = highScore.highScore;
    }
}
