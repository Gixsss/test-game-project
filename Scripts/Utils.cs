using UnityEngine;

public static class Utils
{
    private static Camera _cachedCamera;
    
    private static Camera MainCamera => _cachedCamera ? _cachedCamera : _cachedCamera = Camera.main;
    
    public static Vector2 GetMousePosition()
    {
        return MainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}