using UnityEngine;

public class TowerAudio : MonoBehaviour
{
    AudioClip weaponSound;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        
    }

    public void PlayWeaponSound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
