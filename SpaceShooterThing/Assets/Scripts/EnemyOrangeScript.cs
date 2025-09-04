using UnityEngine;

public class EnemyOrangeScript : MonoBehaviour
{
    [SerializeField] GameObject LaserPrefab;
    void Start()
    {
        InvokeRepeating("FireLaser", 0 , 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -6.8f, 0) * Time.deltaTime;
    }
    void FireLaser()
    {
        Instantiate(LaserPrefab, transform.position + new Vector3(0, -1f, 0), Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instnace.GameOver();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "PlayerLaser" || collision.gameObject.tag == "PlayerExplosion")
        {
            GameManager.instnace.AddScore(20);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

    }
}

