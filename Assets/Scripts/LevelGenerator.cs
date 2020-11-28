using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public const float maxSpawnDistance = 10f;

    private Vector3 lastEndPosition;

    [SerializeField] private Transform StartLedgeSet;
    [SerializeField] private List<Transform> LedgeSets;
    [SerializeField] private PlayerController player;

    public void Awake()
    {
        lastEndPosition = StartLedgeSet.Find("EndPoint").position;
    }

    private void Update()
    {
        Vector3 playerPosition = player.transform.position;

        if (Vector3.Distance(playerPosition, lastEndPosition) < maxSpawnDistance)
        {
            SpawnLedges();
        }
    }
    private void SpawnLedges()
    {
        Transform randomLedge = LedgeSets[Random.Range(0, LedgeSets.Count)];

        Transform Ledge = SpawnLedgeSet(randomLedge, lastEndPosition);
        lastEndPosition = Ledge.Find("EndPoint").position;
    }

    private Transform SpawnLedgeSet(Transform Ledge, Vector3 spawnPosition)
    {
        Transform lastPosition = Instantiate(Ledge, (spawnPosition), Quaternion.identity);
        return lastPosition;
    }
}
