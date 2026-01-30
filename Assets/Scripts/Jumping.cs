using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [Header("Jump setup")]
    // the key used to activate the push
    public KeyCode key = KeyCode.Space; 

    public float jumpForce = 2.5f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    private Vector2 movement;

    // References
    private Rigidbody2D rigidbody;
    public Animator animator;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Is Grounded?
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Is Jumping?
        if (Input.GetKeyDown(key) && isGrounded == true)
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void LateUpdate()
    {
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("VerticalVelocity", rigidbody.velocity.y);
    }
}
