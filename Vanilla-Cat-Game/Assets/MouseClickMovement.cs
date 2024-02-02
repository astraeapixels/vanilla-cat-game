using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class MouseClickMovement : MonoBehaviour
{

public float speed = 10f;
private float lastClickedPos;
bool moving;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = new Vector2(lastClickedPos, 0.0f);
        moving = true;


         if(Input.GetMouseButtonDown(0)){
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            
         }
      

        if(moving && (Vector2)transform.position != target){
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }
        else
        {
            moving = false;
        }
    }

    // void OnMouseDrag(){
    //     transform.position = new UnityEngine.Vector3(lastClickedPos.x, transform.position.y, transform.position.z);
    // }
}
