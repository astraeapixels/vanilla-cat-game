using UnityEngine;
using PrimeTween;

public class CinematicBars : MonoBehaviour
{
    [SerializeField] private RectTransform topBar, bottomBar;
    [SerializeField] private float fadeTime;

        public void ShowBars()
        {
            Tween.UIAnchoredPosition(topBar, new Vector2(0f, 162f), fadeTime, ease: Ease.InOutQuint, 1);

            Tween.UIAnchoredPosition(bottomBar, new Vector2(0f, -162f), fadeTime, ease: Ease.InOutQuint, 1);
        }

        public void HideBars()
        {
            Tween.UIAnchoredPosition(topBar, new Vector2(0f, 198f), fadeTime, ease: Ease.InOutQuint, 1);

            Tween.UIAnchoredPosition(bottomBar, new Vector2(0f, -198f), fadeTime, ease: Ease.InOutQuint, 1);
        }
    }
