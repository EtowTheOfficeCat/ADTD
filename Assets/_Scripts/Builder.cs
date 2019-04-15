using UnityEngine;
using UnityEngine.Events;

public class Builder : MonoBehaviour
{
    public TowerEvent TowerBuilt = new TowerEvent();
    [SerializeField] private BuildMenu buildMenu;
    [SerializeField] private Tower towerPrefab;
    [SerializeField] private float towerYOffset;
    private Player player;
    private Canvas canvas;
    private Camera cam;
    private Vector3 curBuildPos;
    private Transform buildPanelTransform;
    public Tower[] towerShop { get; set; }
    private Platform curPlatform;

    public void Start()
    {
        player = GetComponent<Player>();
        Platform.Clicked.AddListener(DisplayBuildMenu);
        BuildButton.Clicked.AddListener(Build);
        CancelButton.Clicked.AddListener(CancelBuildMenu);
        canvas = buildMenu.GetComponent<Canvas>();
        cam = Camera.main;
        buildPanelTransform = buildMenu.transform.GetChild(0);

    }
    public void Build (Tower tower)
    {
        Tower t = Instantiate(tower, transform);
        t.transform.position =  curBuildPos + Vector3.up * towerYOffset;
        buildPanelTransform.gameObject.SetActive(false);
        TowerBuilt?.Invoke(tower);
    }


    public void DisplayBuildMenu(Platform platform)
    {
        buildMenu.Clear();
        curBuildPos = platform.transform.position;
        curPlatform = platform;
        platform.IsOccupied = true;
        buildPanelTransform.gameObject.SetActive(true);
        buildPanelTransform.position = Utility.WorldToUISpace(canvas, cam, curBuildPos, Vector2.zero);
        buildMenu.Init(this);
    }

    public void CancelBuildMenu()
    {
        curPlatform.IsOccupied = false;
        buildPanelTransform.gameObject.SetActive(false);
       
    }

   
}
