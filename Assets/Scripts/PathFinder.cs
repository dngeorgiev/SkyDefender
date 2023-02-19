using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private WaveConfigSO waveConfig;
    private List<Transform> waypoints;
    private int waypointIndex = 0;

    private void Awake() 
    {
        this.enemySpawner = FindObjectOfType<EnemySpawner>();    
    }

    private void Start()
    {
        this.waveConfig = this.enemySpawner.GetCurrentWave();
        this.waypoints = this.waveConfig.GetWaypoints();
        this.transform.position = this.waypoints[waypointIndex].position;
    }

    private void Update()
    {
        this.FollowPath();
    }

    private void FollowPath()
    {
        if (this.waypointIndex < this.waypoints.Count)
        {
            Vector3 targetPosition = this.waypoints[this.waypointIndex].position;
            float delta = this.waveConfig.GetMoveSpeed() * Time.deltaTime;
            this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, delta);
            if (this.transform.position == targetPosition)
            {
                this.waypointIndex++;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
