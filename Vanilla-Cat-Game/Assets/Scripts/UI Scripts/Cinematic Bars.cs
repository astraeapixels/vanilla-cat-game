using UnityEngine;
using PrimeTween;

public class CinematicBars : MonoBehaviour
{
    [SerializeField] private RectTransform topBar, bottomBar;
    [SerializeField] private float fadeTime;

        public void ShowBars(){
        topBar.transform.localPosition = new Vector3(0f, 198f, 0f);
        Tween.UIAnchoredPosition(topBar, new Vector2(0f, 162f), fadeTime, ease: Ease.InOutQuint, 1);

        bottomBar.transform.localPosition = new Vector3(0f, -198f, 0f);
        Tween.UIAnchoredPosition(bottomBar, new Vector2(0f, -162f), fadeTime, ease: Ease.InOutQuint, 1);
        
    }

        public void HideBars()
        {
        topBar.transform.localPosition = new Vector3(0f, 198f, 0f);
        Tween.UIAnchoredPosition(topBar, new Vector2(0f, 198f), fadeTime, ease: Ease.InOutQuint, 1);

        bottomBar.transform.localPosition = new Vector3(0f, -198f, 0f);
        Tween.UIAnchoredPosition(bottomBar, new Vector2(0f, -198f), fadeTime, ease: Ease.InOutQuint, 1);
        }
    }
