using UnityEngine;

public class Game : MonoBehaviour
{
    public static Camera MainCam { get; private set; }

    [SerializeField] private Level level1; 

    private void Awake()
    {
        MainCam = Camera.main;
        Transform myWorldTransform = level1.GoalTransform;
    }

    private void Start()
    {
        Vector3 spawnPos = level1.SpawnTransform.position;
        Vector3 goalPos = level1.GoalTransform.position;
        level1.Wave1.StartWave(spawnPos, goalPos);
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
}