using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies = new List<Enemy>(8);
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy == null) { return; }
        enemy.EnemyDied.AddListener(OnEnemyDied);
        enemies.Add(enemy);
    }
    private void OnTriggerExit(Collider other)
    { 
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy == null) { return; }
        enemy.EnemyDied.RemoveListener(OnEnemyDied);
        enemies.Remove(enemy);
    }
    public void OnEnemyDied(Enemy enemy)
    {
        print("Enemy died");
        enemies.Remove(enemy);
        enemy.EnemyDied.RemoveListener(OnEnemyDied);
    }
}
