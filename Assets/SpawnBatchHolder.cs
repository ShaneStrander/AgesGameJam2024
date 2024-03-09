using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnBatchHolder", order = 1)]
public class SpawnBatchHolder : ScriptableObject
{
    public ScriptableObject[] scriptableObjects;
}