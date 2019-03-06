using UnityEngine;

public class Player : MonoBehaviour
{
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
        Platform.Clicked.AddListener(builder.Build);
    }
}
