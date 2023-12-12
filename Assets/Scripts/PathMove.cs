using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMove : MonoBehaviour
{
    public float forwardSpeed = 50f;

    void Update()
    {
        transform.Translate(Vector3.back * forwardSpeed * Time.deltaTime);
    }
}
