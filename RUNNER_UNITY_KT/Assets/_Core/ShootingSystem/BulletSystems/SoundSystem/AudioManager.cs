using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip obstacleDestroySound;
    [SerializeField] private AudioSource audioSource;

    public void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound);
    }

    public void PlayObstacleDestroySound()
    {
        audioSource.PlayOneShot(obstacleDestroySound);
    }
}
