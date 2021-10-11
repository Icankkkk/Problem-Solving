using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    
    // atribut untuk ObstacleSpawner
    public GameObject prefabsObstacle;
    private float y_position = -3.8f; // max posisi untuk y
    private float x_position = 8; // max posisi untuk x

    // [edit] Membuat List untuk obstacle
    private List<GameObject> obs = new List<GameObject>();
    private GameObject obsToSpawn;

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", 1, 2);
    }

    void SpawnObstacle()
    {
        for (int i = 0; i < obs.Count; i++)
        {
            if (obs[i].activeSelf == false)
            {
                obs[i].SetActive(true);
                obs[i].transform.position = PosObs();
                obsToSpawn = obs[i];
                return;
            }
        }

        if (obsToSpawn == null)
        {
            obsToSpawn = Instantiate(prefabsObstacle);
            obsToSpawn.transform.position = PosObs();
            obs.Add(obsToSpawn);
        }

        obsToSpawn = null;
    }

    Vector3 RandomPos()
    {
        float xPos = Random.Range(-x_position, x_position);
        float yPos = Random.Range(-y_position, y_position);

        return new Vector3(xPos, yPos, 0);
    }

    Vector3 PosObs()
    {
        Vector3 objPos = RandomPos();

        Vector3 playerPos = FindObjectOfType<PlayerMovement>().gameObject.transform.position;
        while (Vector3.Distance(playerPos, objPos) < 2)
            objPos = RandomPos();

        return objPos;
    }


}
