using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boostraper : MonoBehaviour
{
    [SerializeField] public float interval;
    [SerializeField] public TMP_Text textScore;
    [SerializeField] private ScoreView scoreView;
    private ScoreModel scoreModel;

    void Start()
    {
        scoreModel = new ScoreModel();
        scoreView.scoreText = textScore;
        scoreModel.interval = interval;
    }

    void Update()
    {
        scoreModel.UpdateScore();
        int currentScore = scoreModel.GetScore();
        scoreView.UpdateScoreText(currentScore);
    }
}