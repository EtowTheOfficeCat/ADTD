using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : weapon
{
    [SerializeField] private Enemy projectile;
    [SerializeField] private Transform rotTransform;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private Transform projectileSpawnPoint2;
    [SerializeField] private float rate = 0.5f;
    private BulletPool pool;
    private bool isActive; 

    private float timer;

    private void Start()
    {
        pool = GameObject.Find("BulletPool").GetComponent<BulletPool>();
    }

    public override void OnWeapon()
    {
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
        timer += Time.deltaTime;
        if (timer >= rate && Physics.SphereCast (transform.position, 1f, transform.forward, out RaycastHit hit ) && isActive) 
        {
            timer = 0f;
            projectile pr = pool.GetNext( projectileSpawnPoint.position, rotTransform.rotation);
            projectile prj = pool.GetNext( projectileSpawnPoint2.position, rotTransform.rotation);
            

            //Instantiate(projectile, projectileSpawnPoint.position, rotTransform.rotation);
            //Instantiate(projectile, projectileSpawnPoint2.position, rotTransform.rotation);
        }
    }

    public override void SetActive(bool active)
    {
        isActive = active;
    }
} 
