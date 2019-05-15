using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class EnemyEvent : UnityEvent<Enemy>
{

}

[System.Serializable]
public class PlatformEvent : UnityEvent<Platform>
{

}

[System.Serializable]
public class TowerEvent : UnityEvent <Tower>
{
    //wird benutzt von scripte....
}

[System.Serializable]
public class WeaponEvent : UnityEvent<Weapon>
{
    //wird benutzt von scripte....
}