
using UnityEngine;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int numOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}



public class wavesSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;

    private Wave currentWave;
    private int currentWaveNumber;

    private void Update()
    {
         currentWave = waves[currentWaveNumber];

    }

    void SpawnWaves()
    {
        GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];

    }
}
