using System;
using System.Collections.Generic;
using System.Threading;
using UnitBehaviours.Move;
using Units;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] protected GameManager gameManager = null;
    [SerializeField] protected float timeUntilNextSpawn = 1f;

    [SerializeField] protected float spawnsPerSecond = 1f;
    [SerializeField] private UnitMoveBehaviour unitMovement;

    [SerializeField] private List<Unit> spawnPrefabs = new();

    // [SerializeField] private List<Spawner> defaultMoveTargets = new();
    public static readonly List<Spawner> AllFactionSpawner = new();

    private void Awake()
    {
        AllFactionSpawner.Add(this);
    }

    private void Start()
    {
        timeUntilNextSpawn = 1.0f / spawnsPerSecond;
        // unitMovement.targetObjectives = defaultMoveTargets;
    }

    private void OnDestroy()
    {
        if (AllFactionSpawner.Count == 2)
        {
            AllFactionSpawner.Remove(this);
            GameManager.State = GameManager.GameState.GameOver;
        }
        else
        {
            AllFactionSpawner.Remove(this);
        }
    }

    private void Update()
    {
        if (GameManager.State == GameManager.GameState.Running)
        {
            timeUntilNextSpawn -= Time.deltaTime;
            if (timeUntilNextSpawn <= 0.0f)
            {
                timeUntilNextSpawn = 1.0f / spawnsPerSecond;
                if (spawnPrefabs.Count > 0)
                {
                    Spawn();
                }
            }
        }
    }

    private void Spawn()
    {
        Unit unit = Instantiate(spawnPrefabs[Random.Range(0, spawnPrefabs.Count - 1)],
            transform.localPosition + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0),
            Quaternion.identity);
        unit.GetComponent<UnitHealth>().MainCamera = mainCamera;
    }
}