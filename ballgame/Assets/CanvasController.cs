using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    public void ToggleCanvas()
    {
        if (canvas != null)
        {
            canvas.enabled = !canvas.enabled;
        }
    }

    public void DisableCanvas()
    {
        if (canvas != null)
        {
            canvas.enabled = false;
        }
    }

    public void EnableCanvas()
    {
        if (canvas != null)
        {
            canvas.enabled = true;
        }
    }
}