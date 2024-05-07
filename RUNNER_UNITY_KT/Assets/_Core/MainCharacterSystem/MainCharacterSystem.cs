using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterSystem : MonoBehaviour
{
    [SerializeField] public float jumpForce;
    [SerializeField] public float moveSpeed;
    [SerializeField] public Rigidbody rb;
    private bool isGrounded = true;

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
}

