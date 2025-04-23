using UnityEngine;

public class GroundTile : MonoBehaviour 
{
    private GroundSpawner groundSpawner;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject obstaclePrefab;

    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        if (groundSpawner == null)
        {
            Debug.LogError("GroundSpawner not found in the scene!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (groundSpawner != null)
        {
            groundSpawner.SpawnTile(true);
            Destroy(gameObject, 2f);
        }
    }

    public void SpawnObstacle()
    {
        if (obstaclePrefab == null)
        {
            Debug.LogError("Obstacle prefab is not assigned!");
            return;
        }

        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex);

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnCoins()
    {
        if (coinPrefab == null)
        {
            Debug.LogError("Coin prefab is not assigned!");
            return;
        }

        const int coinsToSpawn = 10;
        Collider tileCollider = GetComponent<Collider>();

        if (tileCollider == null)
        {
            Debug.LogError("No Collider component found on the ground tile!");
            return;
        }

        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(tileCollider);
        }
    }

    private Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        if (point != collider.ClosestPoint(point))
        {
            return GetRandomPointInCollider(collider);
        }

        point.y = 1f;
        return point;
    }
}