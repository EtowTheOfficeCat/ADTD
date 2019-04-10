using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies = new List<Enemy>(8);
    [SerializeField] private Transform turretTransform;
    [SerializeField] private float rotSpeed = 80f;
    [SerializeField] private weapon weapon;
    [SerializeField] private bool aimAtFirst = true;

    [SerializeField] private Sprite icon;
    public Sprite Icon
    {
        get { return icon; }
    }

    [SerializeField] private int price = 20;
    public int Price
    {
        get { return price; }
        set { price = value; }
    }

    public Vector3 BuildPosition { get; set; }

    //private bool particleSystemStop = false;
    private bool hadEnemies = false;

    private void Update()
    {
        if (enemies.Count == 0 )
        {
            if (hadEnemies)
            {
                weapon.SetActive(false); 
            }
            hadEnemies = false;
            return;
        }
        if (!hadEnemies)
        {
            weapon.SetActive(true); 
        }
        Aim();
        weapon.OnWeapon();
        hadEnemies = true;

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
        //print("Enemy died");
        enemies.Remove(enemy);
        enemy.EnemyDied.RemoveListener(OnEnemyDied);
    }
}
