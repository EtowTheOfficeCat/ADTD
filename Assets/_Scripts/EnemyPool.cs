using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private int maxCapacity = 50;
    private Stack<Enemy> enemies;
    private int enemySpawned;

    void Awake()
    {
        enemies = new Stack<Enemy>(maxCapacity);
        for (int i = 0; i < 24; i++)
        {
            Enemy ep = Instantiate(enemyPrefab);
            ep.gameObject.SetActive(false);
            enemies.Push(ep);
            ep.GetComponent<Enemy>().Epool = this;
        }
    }

    public Enemy GetNext(Vector3 pos, Quaternion rot)
    {
        Enemy ep;
        if (enemies.Count != 0)
        {
            ep = enemies.Pop();
        }
        else
        {
            ep = Instantiate(enemyPrefab);
            ep.transform.parent = transform;
            ep.gameObject.SetActive(false);
            ep.GetComponent<Enemy>().Epool = this;
        }
        ep.transform.position = pos;
        ep.transform.rotation = rot;
        ep.gameObject.SetActive(true);
        return ep;
    }

    public void ReturnToPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        enemy.transform.position = Vector3.zero;
        enemy.transform.rotation = Quaternion.identity;
        enemy.transform.parent = transform;
        enemies.Push(enemy);
        enemy.ReturnedToPool?.Invoke(enemy);
    }
}
