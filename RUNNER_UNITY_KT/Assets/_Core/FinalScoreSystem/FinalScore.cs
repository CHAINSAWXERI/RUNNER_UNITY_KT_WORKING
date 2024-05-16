using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FinalScore : MonoBehaviour
{
    [SerializeField] public TMP_Text score;
    [SerializeField] public TMP_Text finalScore;
    public void EndGame()
    {
        finalScore.text = "Final " + score.text;
        score.gameObject.SetActive(false);
    }
}
