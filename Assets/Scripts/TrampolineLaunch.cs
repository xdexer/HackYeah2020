using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineLaunch : MonoBehaviour
{

    public Rigidbody2D rb;
    public float launchForce;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trampoline"))
        {
            rb.velocity = Vector2.up * launchForce;
        }
    }

}
