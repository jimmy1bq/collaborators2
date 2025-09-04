using UnityEngine;

public class EnemyBLaser : MonoBehaviour
{
    float LaserSpeed = -15.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { if (transform.position.y <= -10.0f)
        {
            Destroy(this.gameObject);
        }
        transform.position += new Vector3(0, LaserSpeed, 0) * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instnace.GameOver();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
