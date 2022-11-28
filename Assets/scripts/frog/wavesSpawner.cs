
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

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
    public Animator animator;
    public TMP_Text waveName;

    private Wave currentWave;
    private int currentWaveNumber;

    private bool canSpawn = true;
    private bool canAnimate = false;
    private float nextSpawnTime;


    private void Update()
    {
         currentWave = waves[currentWaveNumber];
        SpawnWaves();
        GameObject[] totalEnnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(totalEnnemies.Length == 0)
        {
      
            if (currentWaveNumber + 1 != waves.Length)
            {
                if (canAnimate)
                {
                    waveName.text = waves[currentWaveNumber + 1].waveName;
                    animator.SetTrigger("WaveComplete");
                    canAnimate = false;
                }
               
            }
            else
            {
                Debug.Log("GameFinish");
            }
           

        }

    }

    void spawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
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
                canAnimate = true;
            }
        }
        


    }
}
