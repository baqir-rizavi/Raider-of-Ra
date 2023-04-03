using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Movable
{
    [SerializeField] Transform[] enemies;
    [SerializeField] Vector3[] spawnPositions;

    void Spawn()
    {
        Transform t = null;
        foreach (Vector3 p in spawnPositions)
        {
            t = enemies[Random.Range(0, enemies.Length)];
            Instantiate(t, p, t.rotation);
        }
    }

    protected override void Engage()
    {
        Spawn();
        Destroy(gameObject);
    }
}
