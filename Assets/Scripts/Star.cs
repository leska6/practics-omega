using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        {
            Destroy(gameObject);

        }
    }
}
