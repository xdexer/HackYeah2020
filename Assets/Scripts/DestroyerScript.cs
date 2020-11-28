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

    //private void Update()
    //{
    //    //Debug.Log(this.transform.position.y);
    //    screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    //    //Debug.Log(screenBounds.y);
    //    Vector3 DestroyerPosition = new Vector3(0.0f, -screenBounds.y - offset);
    //    this.transform.position = DestroyerPosition;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Game Over");
            x.GameOver();
        }
        
        Destroy(collision.gameObject);
    }
}
