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

    void SpawnObstacle()
    {
        float xPosition = Random.Range(-x_position, y_position);
        float yPosition = Random.Range(-y_position, x_position);

        GameObject obstacle = Instantiate(prefabsObstacle);
        obstacle.transform.position = new Vector3(xPosition, yPosition, 1);
    }


}
