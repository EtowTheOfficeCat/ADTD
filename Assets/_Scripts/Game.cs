using UnityEngine;

public class Game : MonoBehaviour
{
    public static Camera MainCam { get; private set; }

    [SerializeField] private GameObject blockerPanel;
    [SerializeField] private Level[] levels;
    [SerializeField] private Player player;
    [SerializeField] private Canvas enemyCanvas;
    private GameState gameState = GameState.Play;
    private int curLevelIdx = 0;
    private int curWaveIdx = 0;

    
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
        Player.PressedPause.AddListener(Pause);
        player.Builder.towerShop = levels[0].TowerShop;
        levels[0].Waves[curWaveIdx].StartWave(levels[0].SpawnTransform.position, levels[0].GoalTransform.position);
        Wave.LastEnemyGone.AddListener(SwitchWave);

        // TODO: Unsubscribe at the very end 

    }

    private void SwitchWave()
    {
        Debug.Log($"Starting next wave in { levels[0].WaveDelay} seconds");
        Invoke("StartWave", levels[0].WaveDelay);
        

    }

    private void StartWave()
    {
        Debug.Log("This was the last enemy");
        curWaveIdx++;
        if (curWaveIdx < levels[0].Waves.Length)
        {
            levels[0].Waves[curWaveIdx].StartWave(levels[0].SpawnTransform.position, levels[0].GoalTransform.position);
        }
        //else level is over, switch to next level. 
    }

    private void Pause ()
    {
        if (gameState == GameState.Play)
        {
            Time.timeScale = 0f;
            blockerPanel.SetActive(true);
            gameState = GameState.Pause;
        }
        else if (gameState == GameState.Pause)
        {
            Time.timeScale = 1f;
            blockerPanel.SetActive(false);
            gameState = GameState.Play;
        }
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
    [SerializeField] private Wave[] waves;
    public Wave[] Waves
    {
        get { return waves; }
    }

    [SerializeField] Tower[] towerShop;
    public Tower[] TowerShop
    {
        get { return towerShop; }
    }
    [SerializeField] private float waveDelay;
    public float WaveDelay
    {
        get { return waveDelay; }
    }

}

enum GameState
{
    Intro, Play, Pause, GameOver
}