using UnityEngine;

public class BlueEnemyScript : MonoBehaviour
{
    [SerializeField] GameObject Blaser;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Fire", 0, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -3f, 0) * Time.deltaTime;
    }
    void Fire()
    {
        Instantiate(Blaser, transform.position + new Vector3(0, -1.0f, 0), Quaternion.identity);
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
        { Debug.Log(collision.gameObject.tag);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

    }
}
