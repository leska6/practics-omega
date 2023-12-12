using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
   [SerializeField] KeyCode keyOne;
    public float speed = 0.1f;

    int count = 0;
    public Text countText;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        countText.text = "—чет: " + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyOne))
        {
            Jump();
        };

        /*
            Vector3 direction = new Vector3(0, Input.GetAxisRaw("Vertical"), 0 );
            transform.position += direction * _speed * Time.deltaTime;
            //transform.LookAt(transform.position + direction);*/
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            SceneManager.LoadScene("SampleScene");
            count++;
            countText.text = "—чет: " + count.ToString();
        }
    }


}

