using UnityEngine;
using UnityEngine.UI;
using PrimeTween;

public class ArrowsScript : MonoBehaviour
{
    [SerializeField] private Button leftButton, rightButton;
    [SerializeField] private Vector3 pageStep;
    [SerializeField] private RectTransform initialRect;
    [SerializeField] private float duration;
    private Vector3 targetPos;
    private int currentPreviewIndex;
    [SerializeField] private int maxPreviewIndex;

    // Start is called before the first frame update
    private void Start()
    {   
    }

    private void Awake()
    {
        currentPreviewIndex = 1;
        targetPos = initialRect.localPosition;
    }       


    // Update is called once per frame
    public void ShowNextPreview()
    {
        if(currentPreviewIndex < maxPreviewIndex)
        {
            currentPreviewIndex++;
            targetPos += pageStep;
            MovePreview(duration, targetPos);
        }
    
    }
    public void ShowPreviousPreview()            
    {  
       if(currentPreviewIndex > 1)
        {
            currentPreviewIndex--;
            targetPos -= pageStep;
            MovePreview(duration, targetPos);
        }
    }

    private void MovePreview(float _duration, Vector3 _targetPos)
    {
        Tween.LocalPosition(initialRect, _targetPos, _duration, Ease.InOutCubic);
    }
    
    }
