using UnityEngine;

public class AdjustUI : MonoBehaviour
{
    private float posYFactor = 0.22500008f;
    private float scaleFactor = 0.0009642860586735924f;
    private float initialCanvasHeightForPos = 1333.333f; // corresponds to 800*480 resolution
    private float initialCanvasHeightForScale = 1644.444f;
    private float initialPosY = -450f;
    private float parentCanvasHeight;
    private float maxNextBtnScale = 0.89172f;

    public GameObject content;
    public GameObject nextBtn;
    public GameObject textArea;
    public GameObject infoText;
    public GameObject scrollArea;

    void Start()
    {
        // Y Position Adjustment
        parentCanvasHeight = this.GetComponent<RectTransform>().rect.height;
        float canvasHeightOffset = parentCanvasHeight - initialCanvasHeightForPos;
        float posYOffset = canvasHeightOffset * posYFactor;
        RectTransform r = scrollArea.GetComponent<RectTransform>();
        float newYPos = initialPosY - posYOffset;
        r.localPosition = new Vector3(0, newYPos, 0);
        nextBtn.transform.localPosition = new Vector3(nextBtn.transform.localPosition.x, newYPos, nextBtn.transform.localPosition.z);

        // Scale Adjustment
        canvasHeightOffset = parentCanvasHeight - initialCanvasHeightForScale;
        float scaleOffset = canvasHeightOffset * scaleFactor;

        foreach (Transform child in content.transform)
        {
            Vector3 scale = child.transform.localScale;
            child.transform.localScale += new Vector3(scaleOffset, scaleOffset, 0);
        }

        if (nextBtn.transform.localScale.x + scaleOffset/2 < maxNextBtnScale)
        {
            nextBtn.transform.localScale += new Vector3(scaleOffset / 2, scaleOffset / 2, 0);
        }
        textArea.transform.localScale += new Vector3(scaleOffset/2, scaleOffset/2, 0);
        infoText.transform.localScale += new Vector3(scaleOffset/2, scaleOffset/2, 0);
    }
}
