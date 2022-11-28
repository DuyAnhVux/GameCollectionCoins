using UnityEngine;

public class GroundTile : MonoBehaviour
{
    //Obstacle
    [SerializeField] GameObject[] ObstaclePrefabs;
    public Transform[] SpawnObstaclePos;

    //Enemy
    public GameObject enemy;
    public Transform[] SpawnEnemyPos;
    public float spawnTime = 5;
    private float time = 0;

    //Coin
    [SerializeField] GameObject coinPrefabs;
    [SerializeField] GameObject coinSpeedPrefabs;
    void Start()
    {
        SpawnObstacles();
        SpawnCoins();
        SpawnCoinSpeed();
    }
    void Update()
    {
        SpawnEnemy();
    }
    public void SpawnEnemy()
    {
        if (time > spawnTime)
        {
            int index = Random.Range(0, 3);
            GameObject ob = Instantiate(enemy, SpawnEnemyPos[index]);
            Destroy(ob, 220f);
            time = 0;
        }
        time = time + Time.deltaTime;
    }
    public void SpawnObstacles()
    {
        int index = Random.Range(0, 2);
        int ObstacleSpawnPosition = Random.Range(1, 7);

        Transform SpawnPoint = transform.GetChild(ObstacleSpawnPosition).transform;
        Instantiate(ObstaclePrefabs[index], SpawnPoint.position, Quaternion.identity, transform);
    }
    Vector3 GetRandomCoin(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomCoin(collider);
        }
        point.y = 1;
        return point;
    }
    public void SpawnCoins()
    {
        int coinSpawn = 6;
        for (int i = 0; i < coinSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefabs, transform);
            temp.transform.position = GetRandomCoin(GetComponent<Collider>());
        }
    }
    public void SpawnCoinSpeed()
    {
        int coinSpeedSpawn = 2;
        for (int i = 0; i < coinSpeedSpawn; i++)
        {
            GameObject temp = Instantiate(coinSpeedPrefabs, transform);
            temp.transform.position = GetRandomCoin(GetComponent<Collider>());
        }
    }
}
