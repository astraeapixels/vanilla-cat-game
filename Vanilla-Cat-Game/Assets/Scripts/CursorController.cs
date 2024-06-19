using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public static CursorController instance;

    public Texture2D normalMouse;
	public Texture2D pressedMouse;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    public void ActivateNormalCursor(){
		Cursor.SetCursor(normalMouse, new Vector2(normalMouse.width / 2, normalMouse.height / 2), CursorMode.Auto);  
	}
    public void ActivatePressedCursor(){
		Cursor.SetCursor(pressedMouse, new Vector2(normalMouse.width / 2, normalMouse.height / 2), CursorMode.Auto);  
	}
}
