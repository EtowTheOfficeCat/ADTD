using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class EnemyEvent : UnityEvent<Enemy>
{

}

[System.Serializable]
public class PlatformEvent : UnityEvent<Vector3>
{

}

[System.Serializable]
public class TowerEvent : UnityEvent <Tower>
{
    //wird benutzt von scripte....
}