using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies = new List<Enemy>(8);
    [SerializeField] private Transform turretTransform;
    [SerializeField] private float rotSpeed = 80f;
    [SerializeField] private weapon weapon;
   


    private void Update()
    {
        if (enemies.Count == 0 ) { return; }
        Aim();
        weapon.OnWeapon();

    }

    private void Aim()
    {
        Vector3 targetDir = enemies[0].transform.position - transform.position;
        targetDir.y = 0f;
        Quaternion targetRot = Quaternion.LookRotation(targetDir, Vector3.up);
        float step = rotSpeed * Time.deltaTime;
        turretTransform.rotation = Quaternion.RotateTowards(turretTransform.rotation, targetRot, step);
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
