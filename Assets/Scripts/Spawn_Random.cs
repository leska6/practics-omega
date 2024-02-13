/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Random : MonoBehaviour
{
    public float spawn_delay = 1.0f;
    public float spawn_radius = 4f;
    public GameObject prefab;
    public Transform spawn_point;
    public Vector3 volume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Alpha0)) StartCoroutine("Circle_spawn");
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            StartCoroutine(Circle_spawn());
        }

    }

    IEnumerator Circle_spawn()
    {
        int spawn_count = 400;
        // GameObject parent = new GameObject();
        GameObject parent = new GameObject("SpawnedObjectsParent");
        while (spawn_count > 0)
        {
            spawn_count--;
            //  GameObject obj = Instantiate(prefab, Random.insideUnitSphere * spawn_radius, Quaternion.identity, parent.transform);
            //   obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.rotation.z);
            //  yield return new WaitForSeconds(spawn_delay);
            // Генерация случайной позиции внутри цилиндра
            float angle = Random.Range(0f, Mathf.PI * 2); // Угол в радианах для определения направления вокруг оси Y
            float distance = 3f; // Случайное 0расстояние от центра
           // float x = Mathf.Cos(angle) * distance;
            float z = Mathf.Sin(angle) * distance;

            float x = Random.Range(-volume.x * 0.5f, volume.x * 0.5f);
           
            // float y = Mathf.Sin(angle) * distance;
            float y = Random.Range(-volume.y * 0.5f, volume.y * 0.5f); // Высота внутри заданного объёма (размер по оси Y цилиндра)

            Vector3 spawnPos = spawn_point.position + new Vector3(x, y, z); // Использование точки спавна

            GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity, parent.transform);

            yield return new WaitForSeconds(spawn_delay);

        }
    }*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Random : MonoBehaviour
{
    public float spawn_delay = 10;
    public float spawn_radius = 0;

    public GameObject prefab;

    public Transform spawn_point;
    public float minHeight = -1f; // Минимальная высота цилиндра
    public float maxHeight = 1f; // Максимальная высота цилиндра

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) StartCoroutine("Cylinder_spawn");
    }

    IEnumerator Cylinder_spawn()
    {
        int spawn_count = 400;
        GameObject parent = new GameObject("ParentObject");
        while (spawn_count > 0)
        {
            spawn_count--;

            // Угол и радиус для определения положения в окружности цилиндра
            float angle = Random.Range(0, Mathf.PI * 2);
            float radius = Random.Range(0, spawn_radius);
            // Выбор случайной высоты в пределах высоты цилиндра
            float height = Random.Range(minHeight, maxHeight);

            // Преобразование полярных координат в трехмерные координаты
            Vector3 spawnPos = new Vector3(
                Mathf.Cos(angle)/2,
                height,
                Mathf.Sin(angle)/2
            );

            // Применение глобальной ориентации, если указана точка деления
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

