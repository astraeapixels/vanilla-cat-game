using UnityEngine;

public class CameraZoomController : MonoBehaviour
{   
    public Camera zoomCamera;
    [SerializeField] private float zoomIncrement = 1f;
    public float currentZoomLevel;
    private float minZoom = 4f;
    private float maxZoom = 5f;
    // Start is called before the first frame update
    void Start()
    {
        currentZoomLevel = zoomCamera.fieldOfView;
    }

    // Update is called once per frame
    public void OnDialogueEvent()
    {
        float newZoom = currentZoomLevel - zoomIncrement;
        zoomCamera.fieldOfView = Mathf.Clamp(newZoom, minZoom, maxZoom);
    }
}
