using UnityEngine;
using DG.Tweening;


public class CinematicBars : MonoBehaviour
{
    [SerializeField] private RectTransform topBar, bottomBar;
     [SerializeField] private float fadeInTime;
    [SerializeField] private float fadeOutTime;
    [SerializeField] private CanvasGroup cinematicBarsGroup;
    
    private void Awake()
    {
    }

        public void ShowBars(){
        cinematicBarsGroup.alpha = 1f;
        topBar.transform.localPosition = new Vector3(0f, 198f, 0f);
        topBar.DOAnchorPos(new Vector2(0f, 162f), fadeInTime, false).SetEase(Ease.InOutQuint);
        cinematicBarsGroup.DOFade(1, fadeInTime);

        cinematicBarsGroup.alpha = 1f;
        bottomBar.transform.localPosition = new Vector3(0f, -198f, 0f);
        bottomBar.DOAnchorPos(new Vector2(0f, -162f), fadeInTime, false).SetEase(Ease.InOutQuint);
        cinematicBarsGroup.DOFade(1, fadeInTime);
    }

        public void HideBars()
        {
        cinematicBarsGroup.alpha = 1f;
        topBar.transform.localPosition = new Vector3(0f, 198f, 0f);
        topBar.DOAnchorPos(new Vector2(0f, 198f), fadeInTime, false).SetEase(Ease.InOutQuint);
        cinematicBarsGroup.DOFade(1, fadeInTime);

        cinematicBarsGroup.alpha = 1f;
        bottomBar.transform.localPosition = new Vector3(0f, -198f, 0f);
        bottomBar.DOAnchorPos(new Vector2(0f, -198f), fadeInTime, false).SetEase(Ease.InOutQuint);
        cinematicBarsGroup.DOFade(1, fadeInTime);
        }
    }
