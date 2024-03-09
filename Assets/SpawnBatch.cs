using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnBatch", order = 1)]
public class SpawnBatch : ScriptableObject
{
    public GameObject enemyPrefab;
    public int numberOfPrefabsToCreate;

    [Header("Time between spawn in frames. If 0, all spawn at the same time")]
    public float spawnInterval;

    [Header("Type of spawn. Only check one of these")]   
    public bool samePos;
    public bool randomPos;
    public bool evenSpreadPos;
}