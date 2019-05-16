using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyEvent ReturnedToPool = new EnemyEvent();
    public static EnemyEvent ReachedGoal = new EnemyEvent();
    public static EnemyEvent EnemyDied = new EnemyEvent();
    [SerializeField] private HealthBar healthBarPrefab;
    [SerializeField] private Vector2 offSet;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private int maxHitPoints = 10;
    
    [SerializeField] protected AudioClip enemyDiedSound;
    public AudioClip EnemyDiedSound
    {
        get { return enemyDiedSound; }
    }

    private HealthBar healthBar;
    private Canvas enemyCanvas;
    private int hitPoints;
    private EnemyPool ePool;

    public EnemyPool Epool
    {
        set { ePool = value; }
    }



    private void OnEnable()
    {
        enemyCanvas = Game.Instance.EnemyCanvas;
        healthBar = Instantiate(healthBarPrefab, enemyCanvas.transform);
        healthBar.transform.position = Utility.WorldToUISpace(enemyCanvas, Game.MainCam, transform.position, offSet);
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
        if (other.CompareTag("Goal"))
        {
            ePool.ReturnToPool(this);
            print("entered");
            ReachedGoal?.Invoke(this);
        }
    }

    public void TakeDamage()
    {
        hitPoints -= 1;
        healthBar.FillImage.fillAmount = hitPoints / (float)maxHitPoints;
        if(hitPoints <= 0)
        {
            ePool.ReturnToPool(this);
        }
    }

    private void OnDisable()
    {
        
        if (healthBar != null)
        {
            Destroy(healthBar.gameObject);
        }
        //EnemyDied?.Invoke(this);
        
    }
    
    



}
