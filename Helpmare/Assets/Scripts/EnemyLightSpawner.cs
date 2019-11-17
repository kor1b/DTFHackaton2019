using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyLightSpawner : MonoBehaviour
{
    [SerializeField] private Seeker _seeker;

    private Vector2 lightSpawnPos;

    [SerializeField] private GameObject enemyLightPrefab;
    private GameObject enemyLight;

    /// <summary>
    /// Calculate next position for spawn
    /// </summary>
    /// <returns></returns>
    private Vector2 GetNextSpawnPos()
    {
        RaycastHit2D hit;

        for (int i = 0; i < _seeker.lastCompletedVectorPath.Count; i++)
        {
            var objs = Physics2D.OverlapCircleAll (_seeker.lastCompletedVectorPath[i], .1f);

            for (int j = 0; j < objs.Length; j++)
            {
                if (objs[j].CompareTag ("Entrance"))
                {
                    return objs[j].transform.position;
                }
            }
        }

        return Vector2.zero;
    }

    /// <summary>
    /// Instantiate or move to another position light
    /// </summary>
    private void CreateLight()
    {
        if (enemyLight == null)
            enemyLight = Instantiate (enemyLightPrefab);

        enemyLight.transform.position = GetNextSpawnPos();
    }
}