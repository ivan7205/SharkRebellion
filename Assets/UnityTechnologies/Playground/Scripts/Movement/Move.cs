using UnityEngine;
using System.Collections;
[AddComponentMenu("Playground/Movement/Move")]
[RequireComponent(typeof(Rigidbody2D))]
public class Move : Physics2DObject
{
    [Header("Input keys")]
    public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;
    [Header("Movement")]
    [Tooltip("Speed of movement")]
    public float speed = 5f;
    public Enums.MovementType movementType = Enums.MovementType.AllDirections;
    [Header("Orientation")]
    public bool orientToDirection = false;
    // The direction that will face the player
    public Enums.Directions lookAxis = Enums.Directions.Up;
    private Vector2 movement, cachedDirection;
    private float moveHorizontal;
    private float moveVertical;
    public Animator animator;
    public float GetKeyDown;

    // ADDED: References to the shooters
    private ObjectShooter[] objectShooters;

    void Start()
    {
        animator = GetComponent<Animator>();
        // ADDED: Get all ObjectShooters from the player
        objectShooters = GetComponents<ObjectShooter>();
    }

    // Update gets called every frame
    void Update()
    {
        animator.SetBool("Idle", movement == Vector2.zero);
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("ShootShort");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetTrigger("ShootLong 0");
        }
        // Moving with the arrow keys
        if (typeOfControl == Enums.KeyGroups.ArrowKeys)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal2");
            moveVertical = Input.GetAxis("Vertical2");
        }
        //zero-out the axes that are not needed, if the movement is constrained
        switch (movementType)
        {
            case Enums.MovementType.OnlyHorizontal:
                moveVertical = 0f;
                break;
            case Enums.MovementType.OnlyVertical:
                moveHorizontal = 0f;
                break;
        }

        movement = new Vector2(moveHorizontal, moveVertical);

        // FIXED: Now updates shooter direction when player changes direction
        if (orientToDirection)
        {
            if (movement.sqrMagnitude >= 0.01f)
            {
                cachedDirection = movement;

                // NEW: Update shoot direction for all shooters
                foreach (var shooter in objectShooters)
                {
                    if (shooter != null)
                    {
                        // For horizontal movement only, adjust X direction
                        shooter.shootDirection = new Vector2(Mathf.Sign(moveHorizontal), shooter.shootDirection.y);
                    }
                }
            }
            Utils.SetAxisTowards(lookAxis, transform, cachedDirection);
        }

        Vector3 move = new Vector3(moveHorizontal * speed, moveVertical * speed);
        transform.position += move * Time.deltaTime;
    }

    // FixedUpdate is called every frame when the physics are calculated
    void FixedUpdate()
    {
        // Apply the force to the Rigidbody2d
        rigidbody2D.AddForce(movement * speed * 10f);
    }
}