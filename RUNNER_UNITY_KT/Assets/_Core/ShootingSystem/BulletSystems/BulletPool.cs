using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    public List<GameObject> pool = new List<GameObject>();

    public GameObject InstantiateBullet(Vector3 position, Quaternion rotation)
    {
        GameObject newBulletObject = Instantiate(bulletPrefab, position, rotation);
        pool.Add(newBulletObject);
        return newBulletObject;
    }

    public GameObject GetBullet()
    {
        foreach (GameObject bullet in pool)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true); // Активируем неактивную пулю
                return bullet;
            }
        }
        return InstantiateBullet(Vector3.zero, Quaternion.identity); // Если нет неактивных пуль в пуле, создаем новую
    }
}