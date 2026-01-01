using UnityEngine;
using UnityEngine.InputSystem;

public class SlingShotArea : MonoBehaviour
{
    [SerializeField] private LayerMask _slingshotAreaMask;
    
    public bool IsWithinSlingshotArea()
    {
        Vector2 mousePos = InputManager.MousePosition;
    
        // 检查鼠标是否在屏幕范围内
        if (mousePos.x < 0 || mousePos.x > Screen.width || mousePos.y < 0 || mousePos.y > Screen.height)
        {
            return false;
        }
    
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
    
        // 检查转换结果是否有效
        if (float.IsNaN(worldPosition.x) || float.IsNaN(worldPosition.y) || 
            float.IsInfinity(worldPosition.x) || float.IsInfinity(worldPosition.y))
        {
            return false;
        }
    
        return Physics2D.OverlapPoint(worldPosition, _slingshotAreaMask);
    }
}
