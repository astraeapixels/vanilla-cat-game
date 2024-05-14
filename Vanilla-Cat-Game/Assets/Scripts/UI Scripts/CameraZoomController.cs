using JetBrains.Annotations;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{   
    [SerializeField] private Camera zoomCamera;
    [SerializeField] private float zoomIncrement = 1f;
    [SerializeField]private float currentZoomLevel;
    [SerializeField]private float minZoom;
    [SerializeField]private float maxZoom;
    // Start is called before the first frame update
    void Start()
    {
        currentZoomLevel = zoomCamera.orthographicSize;
    }

    // Update is called once per frame
    public void OnDialogueEvent()
    {
        float newZoom = currentZoomLevel - zoomIncrement;
        zoomCamera.orthographicSize = Mathf.Clamp(newZoom, minZoom, maxZoom);
    }
}
