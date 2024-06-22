using UnityEngine;

public class UnitsForce : MonoBehaviour
{
    public GameObject manager;
    public Vector2 location = Vector2.zero;
    public Vector2 velocity;
    private Vector2 goalPos = Vector2.zero;
    private Vector2 currentForce;

    // Start is called before the first frame update
    private void Start()
    {
        velocity = new Vector2(Random.Range(0.01f, 0.1f), Random.Range(0.01f, 0.1f));
        location = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
    }

    private Vector2 seek(Vector2 target)
    {
        return (target - location);
    }

    private void applyForce(Vector2 f)
    {
        Vector3 force = new Vector3(f.x, f.y, 0);
        this.GetComponent<Rigidbody2D>().AddForce(force);
        Debug.DrawRay(this.transform.position, force, Color.white);
    }

    private void flock()
    {
        location = this.transform.position;
        velocity = this.GetComponent<Rigidbody2D>().velocity;

        Vector2 gl;
        gl = seek(goalPos);
        currentForce = gl;
        currentForce = currentForce.normalized;

        applyForce(currentForce);
    }

    //    // Update is called once per frame
    private void Update()
    {
        flock();
        goalPos = manager.transform.position;
    }

}
