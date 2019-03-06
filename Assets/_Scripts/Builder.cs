using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] float towerYOffset;
    public Tower[] towerShop { get; set; }

    public void Build (Vector3 pos)
    {
        Debug.Log("Platform Clicked");
        Tower tower = Instantiate(towerShop[0], transform);
        tower.transform.position = pos + Vector3.up * towerYOffset; 
    }
}
