using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnBatch", order = 1)]
public class BatchSpawnerScriptable : ScriptableObject
{
    public int[] enemyType; //the "ID" of the enemy. 0 Is butterfly, 1 is grasshopper and so on. Bad I know but it works for game jam
    public int numberOfIntervals; 
    public int numberOfPrefabsToCreatePerInterval;

    [Header("Time between intervals in seconds. If 0, all spawn at the same time")]
    public float spawnInterval;
}