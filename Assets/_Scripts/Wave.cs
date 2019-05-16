using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using Random = UnityEngine;

public class Wave : MonoBehaviour
{
    public static UnityEvent LastEnemyGone = new UnityEvent();
    [SerializeField] private float minRate =0.4f;
    [SerializeField] private float maxRate = 2.2f;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private EnemyPool ePool;
    private Vector3 spawnPos;
    private Vector3 goalPos;
    private float timer;
    private float rate;
    [SerializeField] private int numEnemies = 5;
    private int curEnemyIdx;
    private bool maySpawn;

    public int NumEnemies
    {
        get { return numEnemies;  }
    }


    public Enemy [] Enemies { get; private set; }

    private void Awake()
    {
        ePool = GameObject.Find("EnemyPool").GetComponent<EnemyPool>();
        
        rate = UnityEngine.Random.Range(minRate, maxRate);
        
      
    }

    void Update()
    {
        if (maySpawn == false ) { return; }
        timer += Time.deltaTime;
        if (timer>= rate && numEnemies >0)
        {
            timer = 0f;
            SpawnEnemy();
        }
        else if (curEnemyIdx >= numEnemies)
        {
            maySpawn = false;
            timer = 0f;
        }

    }

    private void SpawnEnemy()
    {
        Enemy enemy = ePool.GetNext(transform.position, transform.rotation);
        enemy.ReturnedToPool.AddListener(CheckIfLastEnemy);
        enemy.transform.parent = transform;
        enemy.SetDestiation(goalPos);
        curEnemyIdx++;
    }

    private void CheckIfLastEnemy(Enemy enemy)
    {
        enemy.ReturnedToPool.RemoveListener(CheckIfLastEnemy);
        if (curEnemyIdx >= numEnemies && transform.childCount ==0)
        {
            //Game Bescheid sagen
            LastEnemyGone?.Invoke();

        }
    }

    public void StartWave (Vector3 spawnPos, Vector3 goalPos)
    {
        this.spawnPos = spawnPos;
        this.goalPos = goalPos;
        maySpawn = true;
    }

    
}
