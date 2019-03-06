using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies = new List<Enemy>(8);
    [SerializeField] private Transform turretTransform;
    [SerializeField] private float rotSpeed = 80f;
    [SerializeField] private weapon weapon;
    [SerializeField] private bool aimAtFirst = true;
    private bool particleSystemStop = false;

    private void Update()
    {
        if (enemies.Count == 0 )
        {
            particleSystemStop = true;
            return;
        }
        Aim();
        weapon.OnWeapon();

        

        if (particleSystemStop)
        {
            weapon.SetActive(true);
        }
        else
        {
            weapon.SetActive(false);
        }

    }

    private void Aim()
    {
        Vector3 targetDir = Vector3.right;
        if (aimAtFirst)
        {
            targetDir = enemies[0].transform.position - transform.position; 
        }
        else
        {
            float oldSqrMagnitude = Mathf.Infinity;
            foreach (Enemy enemy in enemies)
            {
                Vector3 dir = enemy.transform.position - transform.position;
                if (dir.magnitude < oldSqrMagnitude)
                {
                    oldSqrMagnitude = dir.magnitude;
                    targetDir = dir;
                }
            }
        }
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
