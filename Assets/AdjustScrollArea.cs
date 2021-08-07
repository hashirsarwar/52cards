using UnityEngine;

public class AdjustScrollArea : MonoBehaviour
{
    private float posYFactor = 0.22500008f;
    private float initialCanvasHeight = 1333.333f; // corresponds to 800*480 resolution
    private float initialPosY = -450f;
    private float parentCanvasHeight;

    void Start()
    {
        parentCanvasHeight = transform.parent.gameObject.GetComponent<RectTransform>().rect.height;
        float canvasHeightOffset = parentCanvasHeight - initialCanvasHeight;
        float posYOffset = canvasHeightOffset * posYFactor;
        RectTransform r = this.GetComponent<RectTransform>();
        r.localPosition = new Vector3(0, initialPosY - posYOffset, 0);
    }
}
