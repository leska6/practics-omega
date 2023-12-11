using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0, Input.GetAxisRaw("Vertical"), 0 );
        transform.position += direction * _speed * Time.deltaTime;
        //transform.LookAt(transform.position + direction);
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}

