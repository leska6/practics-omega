using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] stars;
    public List<Transform> spawnPoints;

    void Start()
    {
        spawnPoints = new List<Transform>(spawnPoints);
        SpawnStars();
    }
    void SpawnStars()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            var spawn = Random.Range(0, spawnPoints.Count);
            Instantiate(stars[i], spawnPoints[spawn].transform.position, Quaternion.identity);
            spawnPoints.RemoveAt(spawn);
        }
    }
}
