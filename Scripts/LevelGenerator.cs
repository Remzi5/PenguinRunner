using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject roadPrefab;
    public GameObject obstaclePrefab;
    public GameObject coinPrefab;

    [Header("Settings")]
    public float roadLength = 30f;
    public int roadsOnScreen = 7;
    private List<GameObject> activeRoads = new List<GameObject>();
    private float spawnZ = 0f;
    private Transform playerTransform;

    private float[] lanes = { -3f, 0f, 3f };

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < roadsOnScreen; i++)
        {
            SpawnRoad(i < 3);
        }
    }

    void Update()
    {
        if (playerTransform.position.z - 60 > (spawnZ - roadsOnScreen * roadLength))
        {
            SpawnRoad(false);
            DeleteRoad();
        }
    }

    private void SpawnRoad(bool isEmpty)
    {
        GameObject go = Instantiate(roadPrefab, Vector3.forward * spawnZ, Quaternion.identity);
        activeRoads.Add(go);

        if (!isEmpty)
        {
            SpawnObjectsRandomly(go.transform);
        }

        spawnZ += roadLength;
    }

    private void SpawnObjectsRandomly(Transform roadTransform)
    {
        int safeLane = Random.Range(0, 3);
        int obstacleLane = -1;

        for (int i = 0; i < 3; i++)
        {
            if (i != safeLane && Random.value > 0.5f)
            {
                Vector3 obsPos = new Vector3(lanes[i], 0.5f, roadTransform.position.z + Random.Range(-5f, 5f));
                Instantiate(obstaclePrefab, obsPos, Quaternion.identity, roadTransform);
                obstacleLane = i;
                break;
            }
        }

        int coinLane;
        do {
            coinLane = Random.Range(0, 3);
        } while (coinLane == obstacleLane);

        int coinCount = Random.Range(3, 8);
        for (int i = 0; i < coinCount; i++)
        {
            Vector3 coinPos = new Vector3(lanes[coinLane], 1f, roadTransform.position.z - 10f + (i * 2.5f));
            Instantiate(coinPrefab, coinPos, Quaternion.identity, roadTransform);
        }
    }

    private void DeleteRoad()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }
}