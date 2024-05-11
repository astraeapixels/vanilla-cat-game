using UnityEngine;
using UnityEngine.UI;

public class CinematicBars : MonoBehaviour
{
    private RectTransform topBar, bottomBar;
    private float changeSizeAmount;
    private float targetSize;
    private bool isActive;
    
    private void Awake()
    {
        CreateBars();
    }

    private void CreateBars()
    {
        GameObject blackBars = new GameObject("topBar", typeof(Image));
        blackBars.transform.SetParent(transform, false);
        blackBars.GetComponent<Image>().color = Color.black;
        topBar = blackBars.GetComponent<RectTransform>();
        topBar.anchorMin = new Vector2(0, 1);
        topBar.anchorMax = new Vector2(1, 1);
        topBar.sizeDelta = new Vector2(0, 0);

        blackBars = new GameObject("bottomBar", typeof(Image));
        blackBars.transform.SetParent(transform, false);
        blackBars.GetComponent<Image>().color = Color.black;
        bottomBar = blackBars.GetComponent<RectTransform>();
        bottomBar.anchorMin = new Vector2(0, 0);
        bottomBar.anchorMax = new Vector2(1, 0);
        bottomBar.sizeDelta = new Vector2(0, 0);
    }
    void Update()
    {
        Vector2 sizeDelta = topBar.sizeDelta;
        sizeDelta.y += changeSizeAmount * Time.deltaTime;
        
        if(isActive)
        {
            if(sizeDelta.y >= targetSize)
            {
                sizeDelta.y = targetSize;
                isActive = false;
            }
        } else{ 
            if(sizeDelta.y <= targetSize)
            {
                sizeDelta.y = targetSize;
            }
        }

        topBar.sizeDelta = sizeDelta;
        bottomBar.sizeDelta = sizeDelta;
    }

    public void ShowBars(float targetSize, float time)
    {
        this.targetSize = targetSize;
        changeSizeAmount = (this.targetSize - topBar.sizeDelta.y) / time;
    }
    public void HideBars(float time)
    {
        targetSize = 0;
        changeSizeAmount = (targetSize - topBar.sizeDelta.y) / time;
        isActive = true;

    }

}
