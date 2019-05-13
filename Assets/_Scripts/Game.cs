using UnityEngine;

public class Game : MonoBehaviour
{
    public static Camera MainCam { get; private set; }

    [SerializeField] private Level[] levels;
    [SerializeField] private Player player;
    private GameState gameState = GameState.Play;
    private int curLevelIdx = 0;

    [SerializeField] private Canvas enemyCanvas;
    public Canvas EnemyCanvas
    {
        get { return enemyCanvas; }
    }

    private static Game instance;
    public static Game Instance
    {
        get
        {
            if (instance != null)
            {
                return instance;
            }
            else
            {
                instance = GameObject.Find("GAME").GetComponent<Game>();
                return instance;
            }
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        MainCam = Camera.main;

    }

    private void Start()
    {
        Vector3 spawnPos = levels[0].SpawnTransform.position;
        Vector3 goalPos = levels[0].GoalTransform.position;
        player.Builder.towerShop = levels[0].TowerShop;
        levels[0].Wave1.StartWave(spawnPos, goalPos);
        Wave.LastEnemyGone.AddListener(SwitchWave);
        // TODO: Unsubscribe

    }

    private void SwitchWave()
    {
        Debug.Log("This was the last enemy");
    }
}

[System.Serializable]
public class Level
{
    [SerializeField] private Transform worldTransform;
    public Transform WorldTransform
    {
        get { return worldTransform; }
    }
    [SerializeField] private Transform spawnTransform;
    public Transform SpawnTransform
    {
        get { return spawnTransform; }
    }
    [SerializeField] private Transform goalTransform;
    public Transform GoalTransform
    {
        get { return goalTransform; }
    }
    [SerializeField] private Wave wave1;
    public Wave Wave1
    {
        get { return wave1; }
    }

    [SerializeField] Tower[] towerShop;
    public Tower[] TowerShop
    {
        get { return towerShop; }
    }


}

enum GameState
{
    Intro, Play, Pause, GameOver
}