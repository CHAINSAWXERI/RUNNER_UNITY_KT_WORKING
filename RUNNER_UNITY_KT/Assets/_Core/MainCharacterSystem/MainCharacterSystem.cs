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

        rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
    }

    void Jump()
    {
        rb.velocity = new Vector3(0, jumpForce, 0);
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }
}
