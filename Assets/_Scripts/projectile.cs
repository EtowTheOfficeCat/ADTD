using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    private float destructionTimer = 7f;
    
    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Speed, ForceMode.Impulse);
    }
    private void Update()
    {
        destructionTimer -= Time.deltaTime;
        if (destructionTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }


}
