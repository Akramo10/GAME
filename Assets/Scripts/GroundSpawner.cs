using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour 
{
    [SerializeField] private GameObject groundTile;
    private Vector3 nextSpawnPoint;
    [SerializeField] private int maxTiles = 20;
    private Queue<GameObject> spawnedTiles = new Queue<GameObject>();

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        spawnedTiles.Enqueue(temp);

        if (spawnedTiles.Count > maxTiles)
        {
            GameObject oldTile = spawnedTiles.Dequeue();
            Destroy(oldTile);
        }

        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
        }
    }

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 3)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
        }
    }
}