using UnityEngine;

public class RayCastProjectile : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    [SerializeField] private LayerMask layermask;
    private float destructionTimer = 7f;
    private Vector3 oldPos;

    private void Start()
    {
        oldPos = transform.position;
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
    private void FixedUpdate()
    {
        CheckCollision();
    }
    private void CheckCollision()
    {
        Vector3 dir = oldPos - transform.position;
        Debug.DrawLine(transform.position, oldPos, Color.blue);
        Ray ray = new Ray(transform.position, dir);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray,  out hitInfo, dir.magnitude, layermask, QueryTriggerInteraction.Collide))
        {  
            Enemy enemy = hitInfo.collider.GetComponent<Enemy>();
            enemy?.TakeDamage();
            Destroy(gameObject);
        }
        oldPos = transform.position;
    }

}
