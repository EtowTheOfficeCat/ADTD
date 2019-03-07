using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class Enemy : MonoBehaviour
{
    
    public EnemyEvent EnemyDied = new EnemyEvent();
    [SerializeField] private LayerMask layerMask;
    public void SetDestiation(Vector3 goalPos)
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goalPos);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        Destroy(gameObject);
    }
    private void OnDisable()
    {
        EnemyDied?.Invoke(this);
        
    }
    private void OnDestroy()
    {
        EnemyDied?.Invoke(this);
    }
    



}
