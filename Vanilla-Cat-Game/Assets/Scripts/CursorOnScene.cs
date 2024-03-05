using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorOnScene : MonoBehaviour
{
   
   void Start()
   {
        CursorController.instance.ActivateNormalCursor();
   }

    void Update()
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
