using UnityEngine;
using System.Collections;

public class MainCharacterSystem : MonoBehaviour
{
    [SerializeField] public float jumpForce;
    [SerializeField] public float moveSpeed;
    [SerializeField] public Rigidbody rb;
    [SerializeField] public GameObject shootPosition;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private LayerMask deathObjectMask;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private FinalScore finalScore;
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
            Shoot();        
        }

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
        if ((groundMask == (groundMask | (1 << collision.gameObject.layer))))
        {
            isGrounded = true;
        }

        if ((deathObjectMask == (deathObjectMask | (1 << collision.gameObject.layer))))
        {
            deathScreen.SetActive(true);
            finalScore.EndGame();
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

    void Shoot()
    {
        if (bulletPool != null && audioManager != null)
        {
            Bullet bullet = bulletPool.GetBullet();
            bullet.gameObject.transform.position = shootPosition.transform.position;
            audioManager.PlayShootSound();
        }

    }
}

