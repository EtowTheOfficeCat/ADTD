using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public static WeaponEvent WeaponFired = new WeaponEvent();
    [SerializeField] protected AudioClip weaponSound;
    public AudioClip WeaponSound
    {
        get { return weaponSound; }
    }
    public abstract void OnWeapon();
    public abstract void SetActive(bool active);
    
}

