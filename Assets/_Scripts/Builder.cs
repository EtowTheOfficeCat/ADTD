using UnityEngine;
using UnityEngine.Events;

public class Builder : MonoBehaviour
{
    public TowerEvent TowerBuilt = new TowerEvent();
    [SerializeField] private BuildMenu buildMenu;
    [SerializeField] private Tower towerPrefab;
    [SerializeField] private float towerYOffset;
    public Tower[] towerShop { get; set; }

    public void Start()
    {
        Platform.Clicked.AddListener(DisplayBuildMenu);
    }
    /*public void Build (Vector3 pos)
    {
        Tower tower = Instantiate(towerShop[0], transform);
        tower.transform.position = pos + Vector3.up * towerYOffset;
        TowerBuilt?.Invoke(tower);
    }*/

    public void DisplayBuildMenu(Vector3 pos)
    {
        Transform builderPanelTransform = buildMenu.transform.GetChild(0);
        builderPanelTransform.gameObject.SetActive(true);
        buildMenu.Init(this);
    }

   
}
