using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    public List<Bullet> pool = new List<Bullet>();

    public Bullet InstantiateBullet(Vector3 position, Quaternion rotation)
    {
        Bullet newBulletObject = Instantiate(bulletPrefab, position, rotation);
        newBulletObject.gameObject.SetActive(false);
        pool.Add(newBulletObject);
        return newBulletObject;
    }

    public Bullet GetBullet()
    {
        foreach (Bullet bullet in pool)
        {
            if (!bullet.gameObject.activeInHierarchy)
            {
                bullet.gameObject.SetActive(true); // Активируем неактивную пулю
                return bullet;
            }
        }
        return InstantiateBullet(Vector3.zero, Quaternion.identity); // Если нет неактивных пуль в пуле, создаем новую
    }
}