using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // atribut untuk ObstacleSpawner
    public GameObject prefabsObstacle;
    private float y_position = -3.8f; // max posisi untuk y
    private float x_position = -8; // max posisi untuk x

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", 1, 2);
    }

    // method untuk spawn pada obstacle
    void SpawnObstacle()
    {
        float xPos = Random.Range(-x_position, y_position);
        float yPos = Random.Range(-y_position, x_position);

        GameObject obs = Instantiate(prefabsObstacle);
        obs.transform.position = new Vector3(xPos, yPos, 1);
    }
}
