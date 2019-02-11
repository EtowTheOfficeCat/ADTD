using System;
using UnityEngine;
using Random = UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private float minRate =0.4f;
    [SerializeField] private float maxRate = 2.2f;
    private Vector3 spawnPos;
    private Vector3 goalPos;
    private float timer;
    private float rate;
    public int curEnemyIdx;
    private bool maySpawn;

    public Enemy [] Enemies { get; private set; }

    private void Awake()
    {
        Enemies = GetComponentsInChildren<Enemy>(true);
        rate = UnityEngine.Random.Range(minRate, maxRate);
    }

    void Update()
    {
        if (maySpawn == false ) { return; }
        timer += Time.deltaTime;
        if (timer>= rate && curEnemyIdx < Enemies.Length)
        {
            timer = 0f;
            SpawnEnemy();
        }
        else if (curEnemyIdx >= Enemies.Length)
        {
            maySpawn = false;
            timer = 0f;
        }

    }

    private void SpawnEnemy()
    {
        Enemy enemy = Enemies [curEnemyIdx];
        enemy.gameObject.SetActive(true);
        enemy.SetDestiation(goalPos);
        curEnemyIdx++;
    }

    public void StartWave (Vector3 spawnPos, Vector3 goalPos)
    {
        this.spawnPos = spawnPos;
        this.goalPos = goalPos;
        maySpawn = true;
    }
}
