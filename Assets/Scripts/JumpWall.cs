using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpWall : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public PlayerController player;
    public float launchForce;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("JumpWall"))
        {
            player.FlipThePlayer();
            rb.velocity = Vector2.up * launchForce;
        }
    }

}
