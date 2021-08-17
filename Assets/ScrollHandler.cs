using UnityEngine;
using UnityEngine.UI;

public class ScrollHandler : MonoBehaviour
{
    private RectTransform contentRT;
    private bool blockBtn = false;
    private int blockBtnCount = 0;
    private int distanceBetweenBtns = 800;
    private float xBound;
    private float initXPos;

    void Start()
    {
        contentRT = transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        xBound = contentRT.anchoredPosition.x - distanceBetweenBtns / 2;
        GetComponent<ScrollRect>().onValueChanged.AddListener(ScrollUpdate);
        initXPos = contentRT.anchoredPosition.x;
    }

    void ScrollUpdate(Vector2 v)
    {
        float posX = contentRT.anchoredPosition.x;

        if (posX > initXPos - distanceBetweenBtns / 3)
        {
            xBound = initXPos - distanceBetweenBtns / 2;
        }

        float closeToCenter = posX % distanceBetweenBtns;

        if (closeToCenter < 50 && posX < xBound)
        {
            GetComponent<ScrollRect>().enabled = false;
            float newXPos = posX - closeToCenter;
            contentRT.anchoredPosition = new Vector2(newXPos, contentRT.anchoredPosition.y);
            blockBtn = true;
            xBound = newXPos - distanceBetweenBtns / 2;
        }
    }

    void Update()
    {
        Input.GetTouch(1);
        if (blockBtn)
        {
            ++blockBtnCount;

            if (blockBtnCount >= 8)
            {
                blockBtn = false;
                GetComponent<ScrollRect>().enabled = true;
                blockBtnCount = 0;
            }
        }
    }
}
