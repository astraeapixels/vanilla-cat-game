using UnityEngine;

public class PointsPath : MonoBehaviour
{
    internal Transform player;
    internal Transform[] position;
    [SerializeField] private Transform[] Points;
    [SerializeField] private float smoothSpeed = 5f;

    [SerializeField] private float rotationSpeed = 10f;
    private int pointsIndex;

    // Start is called before the first frame update
    private void Start()
    {
        //transform.position = Points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if(pointsIndex <= Points.Length-1)
        {
            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, smoothSpeed * Time.deltaTime);

            Vector3 dir = Points[pointsIndex].transform.position - transform.position;
            float angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg - 90f), rotationSpeed * Time.deltaTime);

            if(transform.position == Points[pointsIndex].transform.position)
            {
                pointsIndex += 1;
            }
            if(pointsIndex == Points.Length)
            {
                pointsIndex = 0;
            }
        }
    }
}
