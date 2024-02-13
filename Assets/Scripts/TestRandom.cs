using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRandom : MonoBehaviour
{

    public float spawn_delay = 1.0f;
    public float spawn_radius = 4f;
    public GameObject prefab;
    public Transform spawn_point;
    public float minHeight = -1f; // ����������� ������ ��������
    public float maxHeight = 1f; // ������������ ������ ��������
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha0)) StartCoroutine("Cylinder_spawn");

    }

    IEnumerator Cylinder_spawn()
    {
        int spawn_count = 400;
        GameObject parent = new GameObject("ParentObject");
        while (spawn_count > 0)
        {
            spawn_count--;

            // ���� � ������ ��� ����������� ��������� � ���������� ��������
            float angle = Random.Range(0, Mathf.PI * 2);
            float radius = Random.Range(0, spawn_radius);
            // ����� ��������� ������ � �������� ������ ��������
            float height = Random.Range(minHeight, maxHeight);

            // �������������� �������� ��������� � ���������� ����������
            Vector3 spawnPos = new Vector3(
                Mathf.Cos(angle) / 2,
                height,
                Mathf.Sin(angle) / 2
            );

            // ���������� ���������� ����������, ���� ������� ����� �������
            if (spawn_point != null)
            {
                spawnPos = spawn_point.TransformPoint(spawnPos);
            }

            // Create the object at the calculated position
            GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity, parent.transform);
            yield return new WaitForSeconds(spawn_delay);
        }
    }
}
