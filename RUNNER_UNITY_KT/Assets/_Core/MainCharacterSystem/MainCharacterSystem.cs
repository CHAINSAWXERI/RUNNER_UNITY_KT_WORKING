using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainCharacterSystem : MonoBehaviour
{
    [SerializeField] public float jumpForce;
    [SerializeField] public float moveSpeed;
    [SerializeField] public Rigidbody rb;
    [SerializeField] public GameObject shootPosition;
    private bool isGrounded = true;
    public BulletPool bulletPool;
    public AudioManager audioManager { private get; set; }

    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            CancelInvoke("EndCrawl");
            PerformCrawl();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Shoot2();        }

        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(horizontalInput * moveSpeed, rb.velocity.y, moveSpeed);
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }

    void PerformCrawl()
    {
        transform.Rotate(90, 0, 0);
        rb.velocity = new Vector3(rb.velocity.x, 0, -rb.velocity.z);
        rb.velocity *= 0.5f;
        Invoke("EndCrawl", 1f);
    }

    void EndCrawl()
    {
        transform.Rotate(-90, 0, 0);
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    }

    void Shoot2()
    {
        if (bulletPool != null && audioManager != null)
        {
            Bullet bullet2 = bulletPool.GetBullet();
            bullet2.gameObject.transform.position = shootPosition.transform.position;
            audioManager.PlayShootSound();
        }

    }
}

