using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameManager gameManager = null;
    [SerializeField] protected float timeUntilNextSpawn = 1f;
    [SerializeField] protected float spawnsPerSecond = 1f;
    [SerializeField] protected float spawnTimeStepPerLevel = 0.05f;
    // [SerializeField] protected SpawnerHelper spawnerHelper = null;
    // [SerializeField] private List<Spawnable> spawnPrefabs = new List<Spawnable>();

    private void Update()
    {
        throw new NotImplementedException();
    }
}