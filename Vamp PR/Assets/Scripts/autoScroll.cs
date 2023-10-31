using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoScroll : MonoBehaviour
{
    public float ScrollSpeed = 5;
    private void FixedUpdate()
    {
        float step = ScrollSpeed;

        var cameraPosition = transform.position;
        cameraPosition.x += step;
        transform.position = cameraPosition;
    }
}
