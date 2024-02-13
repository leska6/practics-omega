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
    public Text gameOverText;

    private int score = 1;
    public Text scoreText;

    private Rigidbody rb;
    private float originalMass;
    private float weightIncrease = 15f;
    private float weightDecreaseTime = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalMass = rb.mass;
    }

    private void Update()
    {
        if (Input.GetKey(keyOne))
        {
            Jump();
        }
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    private void Jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            EndGame();
        }
        else if (col.tag == "Obstacle")
        {
            rb.mass += weightIncrease;
            Invoke("ResetWeight", weightDecreaseTime);
            Destroy(col.gameObject);
        }
        else if (col.tag == "schetchik")
        {
            Destroy(col.gameObject);
            scoreText.text = "Счет: " + score.ToString();
            score++;
        }
    }

    private void EndGame()
    {
        // Отключаем движение и вращение объекта игрока
        GetComponent<Rigidbody>().isKinematic = true;
        enabled = false;

        // Отображаем текст "Игра окончена" и счет на экране
        gameOverText.text = "Игра окончена\nСчет: " + (score - 1).ToString();
    }

    private void ResetWeight()
    {
        rb.mass = originalMass;
    }
}