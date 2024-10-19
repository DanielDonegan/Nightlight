using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> enemyTypes = new List<GameObject>();

    public int spawnAmount = 3;
    int waveNum = 1;

    public waveUIControl wuic;

    //Top left
    public Transform spawnPoint1;
    //Bottom right
    public Transform spawnPoint2;

    public LayerMask groundLayers;

    Vector3 hitPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(spawnAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count == 0)
        {
            Debug.Log("No more enemies left");
            NextWave();
        }
    }

    void SpawnEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float xRange = Random.Range(spawnPoint1.position.x, spawnPoint2.position.x);
            float zRange = Random.Range(spawnPoint1.position.z, spawnPoint2.position.z);

            Vector3 ranRayPoint = new Vector3(xRange, 50f, zRange);

            RaycastHit hit;

            if (Physics.Raycast(ranRayPoint, -Vector3.up, out hit, Mathf.Infinity))
            {

                if (hit.transform.gameObject.layer == 6)
                {
                    GameObject newEnemy = Instantiate(enemyTypes[Random.Range(0, enemyTypes.Count)], hit.point, Quaternion.identity);

                    enemies.Add(newEnemy);
                }

                hitPoint = hit.point;
            }
        }
    }

    void NextWave()
    {
        waveNum++;

        int ranSpawn = Random.Range(1, 3);
        spawnAmount += ranSpawn;

        wuic.NextWave(waveNum);

        SpawnEnemies(spawnAmount);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(hitPoint, 1f);
    }
}
