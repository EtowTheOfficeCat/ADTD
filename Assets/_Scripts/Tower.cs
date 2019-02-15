using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies = new List<Enemy>(8);
    [SerializeField] private Transform turretTransform;
    [SerializeField] private projectile projectile;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private Transform projectileSpawnPoint2;
    [SerializeField] private float rotSpeed = 80f;
    [SerializeField] private float rate = 0.5f;
    private float timer;


    private void Update()
    {
        float step = rotSpeed * Time.deltaTime;
        if (enemies.Count == 0) { return; }
        Vector3 targetDir = enemies[0].transform.position - transform.position;
        targetDir.y = 0f;
        Quaternion targetRot = Quaternion.LookRotation(targetDir, Vector3.up);
        turretTransform.rotation = Quaternion.RotateTowards(turretTransform.rotation, targetRot, step);
        timer += Time.deltaTime;
        if (timer>= rate)
        {
            timer = 0f;
            Instantiate(projectile, projectileSpawnPoint.position, turretTransform.rotation);
            Instantiate(projectile, projectileSpawnPoint2.position, turretTransform.rotation);
        }

    }
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
