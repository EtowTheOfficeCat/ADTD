using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static UnityEvent PressedPause = new UnityEvent();
    [SerializeField]private int money = 100;
    public int Money
    {
        get { return money;}
        set { money = value; }
    }


    private Builder builder;
    public Builder Builder
    {
        get { return builder; }
    }

    private void Awake()
    {
        builder = GetComponent<Builder>();
    }

    private void Start()
    {
        builder.TowerBuilt.AddListener(Pay);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PressedPause?.Invoke();
        }
    }

    public void Pay (Tower t)
    {
        Money -= t.Price;
    }
}
