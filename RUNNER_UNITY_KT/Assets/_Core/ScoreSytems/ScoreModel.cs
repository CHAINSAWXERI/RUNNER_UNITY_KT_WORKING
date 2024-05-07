using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel
{
    private int score = 0;
    private float timer = 0f;
    public float interval { private get; set; }

    public void UpdateScore()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            score++;
            timer = 0f;
        }
    }

    public int GetScore()
    {
        return score;
    }
}