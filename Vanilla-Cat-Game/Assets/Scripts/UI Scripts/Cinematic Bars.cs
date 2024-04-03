using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematicBars : MonoBehaviour
{
    private RectTransform topBar, bottomBar;
    
    private void Awake()
    {
       createBars(); 
    }

    private void createBars()
    {
        GameObject blackBars = new GameObject("topBar", typeof(Image));
        blackBars.transform.SetParent(transform, false);
        blackBars.GetComponent<Image>().color = Color.black;
        topBar = blackBars.GetComponent<RectTransform>();
        topBar.anchorMin = new Vector2(0, 1);
        topBar.anchorMax = new Vector2(1, 1);
        topBar.sizeDelta = new Vector2(0, 125);

        blackBars = new GameObject("bottomBar", typeof(Image));
        blackBars.transform.SetParent(transform, false);
        blackBars.GetComponent<Image>().color = Color.black;
        bottomBar = blackBars.GetComponent<RectTransform>();
        bottomBar.anchorMin = new Vector2(0, 0);
        bottomBar.anchorMax = new Vector2(1, 0);
        bottomBar.sizeDelta = new Vector2(0, 125);
    }

}
