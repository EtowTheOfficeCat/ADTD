using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : weapon
{
    [SerializeField] private projectile projectile;
    [SerializeField] private Transform rotTransform;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private Transform projectileSpawnPoint2;
    [SerializeField] private float rate = 0.5f;
    private float timer;

    public override void OnWeapon()
    {
        // Debug.DrawRay(transform.position, transform.up * 10f, Color.red);
        timer += Time.deltaTime;
        if (timer >= rate && Physics.SphereCast (transform.position, 1f, transform.up, out RaycastHit hit )) 
        {
            timer = 0f;
            Instantiate(projectile, projectileSpawnPoint.position, rotTransform.rotation);
            Instantiate(projectile, projectileSpawnPoint2.position, rotTransform.rotation);
        }
    }
} 
