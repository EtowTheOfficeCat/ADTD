using UnityEngine;
using UnityEngine.EventSystems;

public class Platform : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Color hoverColor;
    Color normalColor;
    Renderer rend;


    private void Start()
    {
        rend = GetComponentInChildren<Renderer>();
        normalColor = rend.material.GetColor("_BaseColor");
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        rend.material.SetColor("_BaseColor", hoverColor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        rend.material.SetColor("_BaseColor", normalColor);
    }


}
