using UnityEngine;

public static class Utility 
{
    public static Vector3 WorldToUISpace(Canvas canvas,Camera cam, Vector3 worldPos)
    {
        Vector3 screenPos = cam.WorldToScreenPoint(worldPos);
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPos, canvas.worldCamera, out localPos);
        return canvas.transform.TransformPoint(localPos);
    }
}
