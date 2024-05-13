using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;
    private float currentLifeTime;
    private AudioManager audioManager;

    [Inject]
    public void Construct(AudioManager _audioManager)
    {
        this.audioManager = _audioManager;
    }

    public void Start()
    {
        currentLifeTime = lifetime;
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
        DestroyObstacle(other.gameObject);
        DestroyBullet();
    }


    void DestroyBullet()
    {
        ResetLifeTime();
        gameObject.SetActive(false);
    }

    void DestroyObstacle(GameObject obstacle)
    {
        obstacle.SetActive(false);
        audioManager.PlayObstacleDestroySound();
    }

    public void ResetLifeTime()
    {
        currentLifeTime = lifetime;
    }
}