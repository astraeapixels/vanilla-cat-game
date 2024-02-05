using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollowingCamera : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Transform aim;
    // Start is called before the first frame update
    void Start()
    {
        aim =  GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = aim.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        if(transform.position != desiredPosition){
            Vector3 aimPosition = new Vector3(aim.position.x, aim.position.y, transform.position.z);
            transform.position = Vector3.Lerp(smoothedPosition, aimPosition, smoothSpeed);
        }
    }
}
