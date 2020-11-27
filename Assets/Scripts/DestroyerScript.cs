using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Debug.Log("Collision" + collision.gameObject.tag);
            Destroy(collision.gameObject);
    }
}
