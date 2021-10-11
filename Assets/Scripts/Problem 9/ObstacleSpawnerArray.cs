using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerArray : MonoBehaviour
{
    
    // atribut untuk ObstacleSpawner
    public GameObject[] prefabsObstacle;
    private float y_position = 3.8f; // max posisi untuk y
    private float x_position = 7; // max posisi untuk x

    // [edit] Membuat List untuk obstacle
    private List<GameObject> obs = new List<GameObject>();
    private GameObject obsToSpawn;

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", 3, 1);
    }

    void SpawnObstacle()
    {
        bool isFilled = RandomBoolean();

        for (int i = 0; i < obs.Count; i++)
        {
            if (isFilled)
            {

                if (obs[i].activeSelf == false)
                {
                    obs[i].SetActive(true);
                    obs[i].transform.position = PosObs();
                    obsToSpawn = obs[i];
                    return;
                }
            }

        }

            if (obsToSpawn == null)
            {
                obsToSpawn = Instantiate(prefabsObstacle[isFilled? 0 : 1]);
                obs.Add(obsToSpawn);
                obsToSpawn.transform.position = PosObs();
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

    bool RandomBoolean()
    {
        if (Random.value >= 0.5)
            return true;
        return false;
    }

}
