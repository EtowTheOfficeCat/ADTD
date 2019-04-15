using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    
    public EnemyEvent EnemyDied = new EnemyEvent();
    [SerializeField] private HealthBar healthBarPrefab;
    [SerializeField] private Vector2 offSet;
    [SerializeField] private LayerMask layerMask;
    private HealthBar healthBar;
    private Canvas enemyCanvas;
    [SerializeField] private int maxHitPoints = 10;
    private int hitPoints;

    private void OnEnable()
    {
        enemyCanvas = Game.Instance.EnemyCanvas;
        healthBar = Instantiate(healthBarPrefab, enemyCanvas.transform);
        hitPoints = maxHitPoints;
        //print(enemyCanvas?.name);
    }
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
        healthBar.transform.position = Utility.WorldToUISpace(enemyCanvas, Game.MainCam, transform.position, offSet);
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
        hitPoints -= 1;
        healthBar.FillImage.fillAmount = hitPoints / (float)maxHitPoints;
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        Destroy(healthBar.gameObject);
        EnemyDied?.Invoke(this);
        
    }
    
    



}
