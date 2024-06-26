using UnityEngine;
using Vector2 = UnityEngine.Vector2;


public class MouseClickMovement : MonoBehaviour
{
[SerializeField]
private float speed = 10f;
public Vector2 lastClickedPos;
    private bool moving;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 target = new Vector2(lastClickedPos.x, transform.position.y);

        if(Input.GetMouseButtonDown(0))
        {
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;  
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
