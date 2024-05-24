using UnityEngine;
using PrimeTween;

public class CameraZoomController : MonoBehaviour
{   
    public Camera zoomCamera;
    private float minZoom = 4f;
    private float maxZoom = 5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void OnDialogueEvent()
    {
        Tween.CameraOrthographicSize(zoomCamera, maxZoom, .25f, Ease.InOutCubic);
    }
    public void OutsideDialogueEvent()
    {
        Tween.CameraOrthographicSize(zoomCamera, minZoom, .25f, Ease.InOutCubic);
    }
}
