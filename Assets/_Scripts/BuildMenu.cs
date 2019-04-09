using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    [SerializeField] private BuildButton buildButtonPrefab;
    [SerializeField] private Transform buildPanelTransform;
    public void Init(Builder builder)
    {
        foreach (Tower t in builder.towerShop)
        {
            BuildButton button = Instantiate(buildButtonPrefab, buildPanelTransform);
            button.Init(t);
        }
    }
}
