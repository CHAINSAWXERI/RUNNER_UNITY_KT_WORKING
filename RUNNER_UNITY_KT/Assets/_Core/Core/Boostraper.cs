using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class Boostraper : MonoBehaviour
{
    [SerializeField] private float interval;
    [SerializeField] private TMP_Text textScore;
    [SerializeField] private ScoreView scoreView;
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private MainCharacterSystem characterSystem;
    private ScoreModel scoreModel;

    void Start()
    {
        scoreModel = new ScoreModel();
        scoreView.scoreText = textScore;
        scoreModel.interval = interval;

        characterSystem.audioManager = audioManager;
        characterSystem.bulletPool = bulletPool;

        for (int i = 0; i < 10; i++)
        {
            Bullet newBullet = characterSystem.bulletPool.InstantiateBullet(Vector3.zero, Quaternion.identity);
            newBullet.Construct(audioManager);
            newBullet.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        scoreModel.UpdateScore();
        int currentScore = scoreModel.GetScore();
        scoreView.UpdateScoreText(currentScore);
    }
}