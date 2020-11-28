using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject Player;

    public float speed;


    // Jump modifiers
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;


    // Determines how long after stepping out of the ground player can jump
    public float rememberGroundedFor;
    float lastTimeGrounded;

    // Check if player is standing on GameObject with "Ground" layer
    private bool isGrounded;
    public Transform isGroundedChecker;
    public float checkGroundRadius;

    // Layer to detect which GameObject is ground - set every ground to "Ground" layer
    public LayerMask groundLayer;

    // Determines time, after player can be reverted again
    public float rememberRevertedFor;
    float lastTimeReverted;

    // Check if player collides with GameObject with "StaticWall" layer
    public Transform isRightWallChecker;
    public float checkWallRadius;

    // Layer to detect which GameObject is ground - set every ground to "StaticWall" layer
    public LayerMask staticWallLayer;

    // reference to the Rigidbody2D component
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfStaticWallOverlapped();
        Move();
        Jump();
        BetterJump();
        CheckIfGrounded();
    }

    void Move()
    {
        // float x = Input.GetAxisRaw("Horizontal");
        float moveBy = speed;
        rigidBody.velocity = new Vector2(moveBy, rigidBody.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }
    }

    void BetterJump()
    {
        if (rigidBody.velocity.y < 0)
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rigidBody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (collider != null)
            isGrounded = true;
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }

    void CheckIfStaticWallOverlapped()
    {
        Collider2D colliderRight = Physics2D.OverlapCircle(isRightWallChecker.position, checkWallRadius, staticWallLayer);

        if ( colliderRight != null && Time.time - lastTimeReverted >= rememberRevertedFor)
        {
            Debug.Log("WALL COLLISION");
            lastTimeReverted = Time.time;
            speed *= -1;
            FlipThePlayer();
        }
    }

    void FlipThePlayer()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
