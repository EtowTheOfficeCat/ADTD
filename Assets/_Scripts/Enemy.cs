using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{ 
    public void SetDestiation(Vector3 goalPos)
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goalPos);
    }

    

}
