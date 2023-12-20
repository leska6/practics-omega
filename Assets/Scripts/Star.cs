using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    /*int count = 0;
    public Text Text1;
    void Start()
    {
        count = 0;
        Text1.text = "—чет: " + count.ToString();
    }*/
    private void OnTriggerEnter(Collider col)
    {
       //if (col.tag == "Point")
        {
            Destroy(gameObject);
           //count++;
           // Text1.text = "—чет: " + count.ToString();
        }
    }
}
