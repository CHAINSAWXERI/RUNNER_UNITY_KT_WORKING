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
    private float oldLifeTime;

    [Inject]
    public void Construct(AudioManager audioManager)
    {
        this.audioManager = audioManager;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        oldLifeTime = lifetime;
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
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
        gameObject.SetActive(false);
    }

    void DestroyObstacle(GameObject obstacle)
    {
        audioManager.PlayObstacleDestroySound();
        obstacle.SetActive(false);
    }

    public void Shoot()
    {
        lifetime = oldLifeTime;
    }
}