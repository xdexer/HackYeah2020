using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject Player;
    public Animator animator;

    public BoxCollider2D[] colliderList;

    // Jump modifiers
    [Header("Movement")]
    [Range(1f, 30f)]
    public float speed;
    [Range(1f, 30f)]
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    private bool canJump = true;
    private bool canStandUp = true;
    private bool isSliding = false;
  
    [Space]

    // Determines how long after stepping out of the ground player can jump
    [Header("Checkers")]
    [Tooltip("Determines how long after stepping out of the ground player can jump")]
    public float rememberGroundedFor;
    float lastTimeGrounded;

    // Determines time, after player can be reverted again
    [Tooltip("Determines time, after player can be reverted again")]
    public float rememberRevertedFor;
    float lastTimeReverted;
    [Space]

    // Check if player is standing on GameObject with "Ground" layer
    private bool isGrounded;

    public Transform isGroundedChecker;
    // Check if player collides with GameObject with "StaticWall" layer
    public Transform isRightWallChecker;

    // Check if player collides with ceiling
    public Transform isCeilingChecker;

    public float checkGroundRadius;
    public float checkWallRadius;
    [Space]

    [Header("Layers")]
    // Layer to detect which GameObject is ground - set every ground to "Ground" layer
    public LayerMask groundLayer;

    // Layer to detect which GameObject is ground - set every ground to "StaticWall" layer
    public LayerMask staticWallLayer;

    // reference to the Rigidbody2D component
    private Rigidbody2D rigidBody;

    public Rigidbody2D GetPlayerRigidBody()
    {
            return rigidBody;
    }


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        colliderList = GetComponents<BoxCollider2D>();

        colliderList[1].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfStaticWallOverlapped();
        Move();
        Jump();
        CheckIfCanStandUp();
        Slide();
        AnimationController();
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
        if (canJump && Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }
    }

    void Slide()
    {
        if (Input.GetKeyDown(KeyCode.S) && isGrounded)
        {
            Debug.Log("slide start");
            isSliding = true;
            canJump = false;
            colliderList[0].enabled = false;
            colliderList[1].enabled = true;
        }
        else if(Input.GetKeyUp(KeyCode.S) && isGrounded && canStandUp || !Input.GetKey(KeyCode.S) && canStandUp)
        {
            isSliding = false;
            canJump = true;
            colliderList[0].enabled = true;
            colliderList[1].enabled = false;
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
        {
            isGrounded = true;
        }
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
            FlipThePlayer();
        }
    }

    void CheckIfCanStandUp()
    {
        Collider2D collider = Physics2D.OverlapCircle(isCeilingChecker.position, checkWallRadius);

        if (collider != null)
            canStandUp = false;
        else
            canStandUp = true;
    }

    public void FlipThePlayer()
    {
        speed *= -1;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void AnimationController()
    {

        if (isSliding)
            animator.SetBool("isSliding", true);
        else
            animator.SetBool("isSliding", false);

        if (rigidBody.velocity.y > 0)
        {
            animator.SetBool("isJumping", true);
        }
        else if (rigidBody.velocity.y < 0 && animator.GetBool("isJumping"))
        {
            animator.SetBool("isFalling", true);
        }
        else if (rigidBody.velocity.y == 0 && animator.GetBool("isFalling"))
        {
            animator.SetBool("isFalling", false);
            animator.SetBool("isJumping", false);
        }
        else if (rigidBody.velocity.y < 0)
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
        }
    }

}
