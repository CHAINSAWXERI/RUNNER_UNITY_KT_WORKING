using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;
    [SerializeField] private AudioManager audioManager;
    private float currentLifeTime;

    [Inject]
    public void Construct(AudioManager audioManager)
    {
        this.audioManager = audioManager;
    }

    void Update()
    {
        if(gameObject.activeInHierarchy)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.zero);
        }

        currentLifeTime -= Time.deltaTime;

        if (currentLifeTime <= 0)
        {
            DestroyBullet();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            DestroyObstacle(other.gameObject);
            DestroyBullet();
        }
        else
        {
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        ResetLifeTime();
        gameObject.SetActive(false);
    }

    void DestroyObstacle(GameObject obstacle)
    {
        audioManager.PlayObstacleDestroySound();
        obstacle.SetActive(false);
    }

    public void ResetLifeTime()
    {
        currentLifeTime = lifetime;
    }
}