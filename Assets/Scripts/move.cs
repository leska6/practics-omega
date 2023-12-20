using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
   [SerializeField] KeyCode keyOne;
    public float speed = 0.1f;
    [SerializeField] RandomSpawn SpawnStars;

    void Update()
    {
        if (Input.GetKey(keyOne))
        {
            Jump();
        };
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
        }
        if (col.tag == "Obstacle")
        {
            rb.mass += weightIncrease;
            Invoke("ResetWeight", weightDecreaseTime);
            Destroy(col.gameObject);
        }
    }
  
    private Rigidbody rb;
    private float originalMass;
    private float weightIncrease = 15f;
    private float weightDecreaseTime = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalMass = rb.mass;

    }

    private void ResetWeight()
    {

        rb.mass = originalMass;
    }

    void ResetSpawn(Collider col)
    {
        if (col.tag == "Reset")
        {
            GetComponent<RandomSpawn>().SpawnStars();
        }
    }
}

