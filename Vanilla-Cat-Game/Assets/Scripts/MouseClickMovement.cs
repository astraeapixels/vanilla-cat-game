using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;


public class MouseClickMovement : MonoBehaviour
{
public float speed = 10f;
public Vector2 lastClickedPos;
bool moving;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = new Vector2(lastClickedPos.x, 0.0f);
        moving = true;


        if(Input.GetMouseButtonUp(0)){
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);   
        }
        if(moving && (Vector2)transform.position != lastClickedPos){
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }
        else
        {
            moving = false;
        }
    }
}
