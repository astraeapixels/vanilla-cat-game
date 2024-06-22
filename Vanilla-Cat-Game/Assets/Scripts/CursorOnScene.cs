using UnityEngine;

public class CursorOnScene : MonoBehaviour
{
    private void Start()
   {
        CursorController.instance.ActivateNormalCursor();
   }

    private void Update()
    {
           if(Input.GetMouseButtonDown(0)){
                CursorController.instance.ActivatePressedCursor();
            }
             if(Input.GetMouseButtonUp(0)){
                CursorController.instance.ActivateNormalCursor();
            }
    }
     private void OnMouseEnter(){
        CursorController.instance.ActivateNormalCursor();
    }
}
