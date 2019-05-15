using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    AudioClip enemySound;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();

    }

    public void PlayEnemyDiedSound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
