
using UnityEngine;
using UnityEngine.Events;

public class CancelButton : MonoBehaviour
{
    public static UnityEvent Clicked = new UnityEvent();

    private BuildMenu buildMenu;
    
    public void CancelPanel()
    {
        Clicked?.Invoke();
    }
}
