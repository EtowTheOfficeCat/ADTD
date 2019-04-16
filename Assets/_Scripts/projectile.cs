using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    private float destructionInverval = 7f;
    private float destructionTimer;
    private Rigidbody rb;
    public Rigidbody RB
    {
        get { return rb; }
    }
    private BulletPool pool;
    public BulletPool Pool
    {
        set { pool = value; }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }
    private void OnEnable()
    {
        destructionTimer = destructionInverval;
        rb.AddForce(transform.forward * Speed, ForceMode.Impulse);
    }
    private void Update()
    {
        destructionTimer -= Time.deltaTime;
        if (destructionTimer <= 0)
        {
            DestroySelf();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        DestroySelf();
        //Destroy(gameObject);
    }
    private void DestroySelf()
    {
        pool.ReturnToPool(GetComponent<projectile>());
    }
}
