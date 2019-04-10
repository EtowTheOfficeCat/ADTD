using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildButton : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] TMP_Text priceText;
    public static TowerEvent Clicked = new TowerEvent();

    private Tower tower;

    public void Init(Tower tower)
    {
        iconImage.sprite = tower.Icon;
        priceText.text = $"price: {tower.Price}";
        this.tower = tower;
    }
    public void Click()
    {
        Clicked?.Invoke(tower);
    }
}
