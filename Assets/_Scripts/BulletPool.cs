using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private projectile projectilePrefab;
    [SerializeField] private int maxCapacity = 500;
    private Stack<projectile> bullets;
    private int bulletsSpawned;

    void Awake()
    {
        bullets = new Stack<projectile>(maxCapacity);
        for (int i = 0; i < 24; i++)
        {
            projectile pr = Instantiate(projectilePrefab);
            pr.gameObject.SetActive(false);
            bullets.Push(pr);
            pr.GetComponent<projectile>().Pool = this;
        }
    }

    public projectile GetNext(Vector3 pos, Quaternion rot)
    {
        projectile pr;
        if (bullets.Count != 0)
        {
            pr = bullets.Pop();
        }
        else
        {
            pr = Instantiate(projectilePrefab);
            pr.gameObject.SetActive(false);
            pr.GetComponent<projectile>().Pool = this;
        }
        pr.transform.position = Vector3.zero;
        pr.transform.rotation = Quaternion.identity;
        pr.RB.angularVelocity = Vector3.zero;
        pr.RB.velocity = Vector3.zero;
        pr.transform.position = pos;
        pr.transform.rotation = rot;
        pr.gameObject.SetActive(true);
        return pr;
    }

    public void ReturnToPool(projectile pr)
    {
        pr.gameObject.SetActive(false);
        pr.transform.position = Vector3.zero;
        pr.transform.rotation = Quaternion.identity;
        pr.RB.angularVelocity = Vector3.zero;
        pr.RB.velocity = Vector3.zero;
        bullets.Push(pr);
    }
}

