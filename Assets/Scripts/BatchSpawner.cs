using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BatchSpawner : MonoBehaviour
{
    private float timer = 0; // Counting Frames
    public float spawnTimerThresholdMin = 0.2f; // Time needed elapsing until spawning new batch
    public float spawnTimerThresholdMax = 5f;
    public float currentSpawnTimerThreshold = 0;
    public BatchSpawnerScriptable[] batches; // The array of spawn batches
    private int currentInterval = 1;
    private int arrayPos;
    private int numberOfIntervals;
    private float spawnInterval;

    void Start()
    {
        currentSpawnTimerThreshold = Random.Range(spawnTimerThresholdMin, spawnTimerThresholdMax);
        arrayPos = 0;
        ResetBatch(true);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > currentSpawnTimerThreshold && timer < currentSpawnTimerThreshold + spawnInterval * currentInterval && timer > currentSpawnTimerThreshold + spawnInterval * (currentInterval - 1))
        { 
            if (currentInterval <= numberOfIntervals)
            {
                SpawnBatchInInterval(arrayPos);
                currentInterval++;
            }
            else if (currentInterval > numberOfIntervals) 
            {
                ResetBatch(false);
            }
        }
    }

    private void ResetBatch(bool first)
    {
        if (!first)
        { 
            int rand = Random.Range(0, batches.Length - 1);
            arrayPos = rand;
        }

        numberOfIntervals = batches[arrayPos].numberOfIntervals;
        spawnInterval = batches[arrayPos].spawnInterval;
        timer = 0;
        currentInterval = 1;
    }

    void SpawnBatchInInterval(int pos)
    {

        int numberOfInstances = batches[pos].numberOfPrefabsToCreatePerInterval;

        //create a number of instances at the interval
        for (int i = 0; i < numberOfInstances; i++)
        {
            
            switch(batches[arrayPos].enemyType[i])
            {
                case 0:
                    gameObject.GetComponent<EnemyType1Spawner>().SpawnEnemy();
                    
                    break;

                case 1:
                    gameObject.GetComponent<EnemyType2Spawner>().SpawnEnemy();
                    
                    break; 

                case 2:
                    gameObject.GetComponent<EnemyType3Spawner>().SpawnEnemy();
                    
                    break;
            }
        }
    }
}
