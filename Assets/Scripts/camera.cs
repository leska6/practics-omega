using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        transform.Rotate(0, -speed * Time.deltaTime, 0);
    }
}
