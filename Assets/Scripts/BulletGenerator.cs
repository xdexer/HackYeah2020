﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float respawnTime = 1.0f;
    private Vector2 spawnCoord;
    private Vector2 screenBounds;
    private bool spawner = true;
    private void Start()
    {
        Debug.Log(this.transform.position.x);
        spawnCoord = this.transform.position;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        StartCoroutine(bulletWave());
    }

    private void Update()
    {
        
    }

    private void spawnBullet()
    {
        GameObject a = Instantiate(bulletPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), spawnCoord.y);

    }

    IEnumerator bulletWave()
    {
        while (spawner) {
            yield return new WaitForSeconds(respawnTime);
            spawnBullet();
        }
    }
}