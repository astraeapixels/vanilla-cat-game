using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControlCamera : MonoBehaviour
{
    public Transform cursor;
    private new Camera camera;
    
    void Start() {
    	camera = GetComponent<Camera>();
    }
    
    void Update() {
        Vector3 viewPos = camera.WorldToViewportPoint(cursor.position);
        if (viewPos.y > 0.5F){
            print("target is on the top");
        }
        else{
            print("target is on the bottom side!");
        }
    }
}

