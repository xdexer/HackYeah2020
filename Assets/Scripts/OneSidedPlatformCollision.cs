using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSidedPlatformCollision : MonoBehaviour
{
    private GameObject platform;
    private GameObject player;
    private BoxCollider2D platformCollider;
    // Start is called before the first frame update
    void Start()
    {
        platform = transform.parent.gameObject;
        platformCollider = platform.GetComponent<BoxCollider2D>();
        player = GameObject.Find("PF_Character");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Platform Trigger Enter");
        if (player)
            Physics2D.IgnoreCollision(platformCollider, player.GetComponent<BoxCollider2D>(), true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Platform Trigger Exit");
        if (player)
            Physics2D.IgnoreCollision(platformCollider, player.GetComponent<BoxCollider2D>(), false);
    }
}
