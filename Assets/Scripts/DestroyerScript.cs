using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    private Vector2 spawnCoord;
    private Vector2 screenBounds;
    public float offset = 5.0f;
    public GameLogic x;
    private void Start()
    {
        Debug.Log(this.transform.position.x);
        spawnCoord = this.transform.position;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Game Over");
            x.GameOver();
        }

        Destroy(other.gameObject);
    }
}
