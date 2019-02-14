using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject lightBulb = null;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            lightBulb.SetActive(true);
            source.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other)
        {
            lightBulb.SetActive(false);
            source.Stop();

        }
    }
}
