
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

    private bool canSpawn = true;
    private float nextSpawnTime;

    private void Update()
    {
         currentWave = waves[currentWaveNumber];
        SpawnWaves();
        GameObject[] totalEnnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(totalEnnemies.Length == 0 && !canSpawn)
        {
            currentWaveNumber++;
            canSpawn = true;
        }
    }

    void SpawnWaves()
    {

        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.numOfEnemies --;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if(currentWave.numOfEnemies == 0)
            {
                canSpawn = false;
            }
        }
        


    }
}
