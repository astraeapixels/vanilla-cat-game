using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private bool canGrab;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(canGrab){
            if(Input.GetMouseButtonDown(0)){
                CursorController.instance.ActivatePressedCursor();
            }
             if(Input.GetMouseButtonUp(0)){
                CursorController.instance.ActivateNormalCursor();
            }
        }
    }

    private void OnMouseEnter(){
        CursorController.instance.ActivateNormalCursor();

        canGrab = true;
    }

    private void OnMouseExit(){
        canGrab = false;
    }
}
