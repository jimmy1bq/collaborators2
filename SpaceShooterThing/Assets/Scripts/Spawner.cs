using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float SpawnerRate = 2.0f;
    [SerializeField] GameObject EnemyBlackPrefab;
    float xmin;
    float xmax;
    float yspawn;
    void Start()
    {
        xmin = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0, 0)).x;
        xmax = Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0, 0)).x;
        yspawn = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.25f, 0)).y;

        InvokeRepeating("SpawnEnemy", 0, SpawnerRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(xmin,xmax);
        Instantiate(EnemyBlackPrefab, new Vector3(randomX,yspawn,0), Quaternion.identity);
    }
}
