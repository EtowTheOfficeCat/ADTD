using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : weapon
{
    [SerializeField] private Transform beamStartPoint;
    [SerializeField] private float rate = 0.5f;
    [SerializeField] private float range = 4f;
    [SerializeField] private LayerMask layerMask; 
    private float timer;
    public ParticleSystem fireBeam;
    [SerializeField] private List<Enemy> enemies = new List<Enemy>(8);

    private void Awake()
    {
        fireBeam.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        fireBeam.Play();
    }


    public override void OnWeapon()
    {
        Debug.DrawRay(beamStartPoint.position, transform.up * range, Color.red);
        timer += Time.deltaTime;
        if (timer >= rate)
        {
            timer = 0f;
            Ray ray = new Ray(beamStartPoint.position, transform.up);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, range, layerMask, QueryTriggerInteraction.Collide))
            {
                //hitInfo.collider.GetComponent<Enemy>().TakeDamage();
                Debug.Log(hitInfo.collider.name);
                Enemy enemy = hitInfo.collider.GetComponent<Enemy>();
                Debug.Log(enemy == null);
                enemy?.TakeDamage();

            }
        }
    } 
}



//GameObject.FindObjectWithTag("WHATEVER YOU HAVE TAGGED YOUR OBJECT").GetComponent<ParticleSystem>().enableEmission = true;
