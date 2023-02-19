using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject 
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float timeBetweenEnemySpawns = 1f;
    [SerializeField] private float spawnTimeVariance = 0f;
    [SerializeField] private float minimumSpawnTime = 0.2f;

    public Transform GetStartingWaypoint()
    {
        return this.pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();

        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return this.moveSpeed;
    }

    public int GetEnemyCount()
    {
        return this.enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return this.enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(this.timeBetweenEnemySpawns - this.spawnTimeVariance, 
            this.timeBetweenEnemySpawns + this.spawnTimeVariance);

        return Mathf.Clamp(spawnTime, this.minimumSpawnTime, float.MaxValue);
    }
}