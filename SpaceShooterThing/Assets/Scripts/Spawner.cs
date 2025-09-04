using System;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Spawner : MonoBehaviour
{   
    
    [SerializeField] float SpawnerRate = 2.0f;
    [SerializeField] GameObject EnemyBlackPrefab;
    [SerializeField] GameObject EnemyOrangePreFab;
    [SerializeField] GameObject Boss;
    bool enemy2Spawned = true;
    int[] scoreMilestones = new int[] {200,300,350,400,425,500,500,500,500};
    int arrayIndex = 0;



    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {   if (GameManager.instnace.GetScore() >= 50 && enemy2Spawned) {
            enemy2Spawned = false;
            InvokeRepeating("SpawnOrange", 0, 2);
        
        }
      
 if (GameManager.instnace.GetScore() >= scoreMilestones[arrayIndex] && EnemyBossScript.BossAlive==false)
        {Instantiate(Boss, new Vector3(0, 10, 0), Quaternion.identity);
                if (arrayIndex < scoreMilestones.Length - 1)
                {if (arrayIndex + 1 < scoreMilestones.Length - 1)
                    { arrayIndex++;
                    }
                }
            }
    }
    
    void SpawnEnemy()
    {
        float xmin = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0, 0)).x;
        float xmax = Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0, 0)).x;
        float yspawn = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.25f, 0)).y;

        float randomX = Random.Range(xmin, xmax);
        Instantiate(EnemyBlackPrefab, new Vector3(randomX,yspawn,0), Quaternion.identity);
    }
    void SpawnOrange()
    {
        float xmin = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0, 0)).x;
        float xmax = Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0, 0)).x;
        float yspawn = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.25f, 0)).y;

        float randomX = Random.Range(xmin, xmax);
        Instantiate(EnemyOrangePreFab, new Vector3(randomX, yspawn, 0), Quaternion.identity);
    }
}