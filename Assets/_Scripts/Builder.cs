using UnityEngine;
using UnityEngine.Events;

public class Builder : MonoBehaviour
{
    public TowerEvent TowerBuilt = new TowerEvent();
    [SerializeField] private Tower towerPrefab;
    [SerializeField] private float towerYOffset;
    public Tower[] towerShop { get; set; }

    public void Build (Vector3 pos)
    {
        Tower tower = Instantiate(towerShop[0], transform);
        tower.transform.position = pos + Vector3.up * towerYOffset;
        TowerBuilt?.Invoke(tower);
    }
}
