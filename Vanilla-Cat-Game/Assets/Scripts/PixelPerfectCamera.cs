using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour
{
    public Vector2 PixelPerfectClamp(Vector2 movement, float pixelsPerUnit)
    {
        Vector2 vectorInPixels = new Vector2(
            Mathf.RoundToInt(movement.x * pixelsPerUnit), Mathf.RoundToInt(movement.y * pixelsPerUnit));

            return vectorInPixels / pixelsPerUnit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
