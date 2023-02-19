using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigSO> waveConfigs;
    [SerializeField] private float timeBetweenWaves = 0f;
    [SerializeField] private bool isRunning;
    private WaveConfigSO currentWave;

    private void Start()
    {
        StartCoroutine(this.SpawnEnemyWaves());    
    }

    public WaveConfigSO GetCurrentWave()
    {
        return this.currentWave;
    }

    private IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in this.waveConfigs)
            {
                this.currentWave = wave;

                for (int i = 0; i < this.currentWave.GetEnemyCount(); i++)
                {
                    var enemyPrefab = this.currentWave.GetEnemyPrefab(i);

                    Instantiate(enemyPrefab, 
                        this.currentWave.GetStartingWaypoint().position, 
                        Quaternion.identity,
                        this.transform);
                    
                    yield return new WaitForSeconds(this.currentWave.GetRandomSpawnTime());
                }

                yield return new WaitForSeconds(this.timeBetweenWaves);
            }
        } while (this.isRunning);
    }
}
