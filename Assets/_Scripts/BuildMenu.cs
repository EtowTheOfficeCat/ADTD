using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenu : MonoBehaviour
{
    [SerializeField] private BuildButton buildButtonPrefab;
    [SerializeField] private Transform buildPanelTransform;
    [SerializeField] private CancelButton CancelButtonPrefab;
    [SerializeField] private Player player;
    public void Init(Builder builder)
    {
        foreach (Tower t in builder.towerShop)
        {
            BuildButton button = Instantiate(buildButtonPrefab, buildPanelTransform);
            
            button.Init(t);
            if(t.Price> player.Money)
            {
                button.GetComponent<Button>().interactable = false;
            }
            
        }
        CancelButton cancel = Instantiate(CancelButtonPrefab, buildPanelTransform);
    }

    public void Clear()
    {
        foreach(Transform button in buildPanelTransform)
        {
            Destroy(button.gameObject);
        }
    }
}
