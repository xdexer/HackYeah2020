using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float respawnTime = 1.0f;
    private Vector2 spawnCoord;
    private Vector2 screenBounds;
    public int bulletSpawnPoints = 20;
    private bool doOnce = true;
    public float offset = 5.0f;
    private bool spawner = false;
    private void Start()
    {
        Debug.Log(this.transform.position.x);
        spawnCoord = this.transform.position;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    private void Update()
    {
        //Debug.Log(this.transform.position.y);
        if(PointsCounter.pointsCounter > bulletSpawnPoints)
        {
            spawner = true;
            spawnCoord = this.transform.position;
            //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
            ////Debug.Log(screenBounds.y);
            //Vector3 GeneratorPosition = new Vector3(0.0f, screenBounds.y + offset);
            //this.transform.position = GeneratorPosition;
            respawnTime = Random.Range(0.1f, 2.0f);
            if (doOnce)
            {
                doOnce = false;
                StartCoroutine(bulletWave());
            }
        }
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
