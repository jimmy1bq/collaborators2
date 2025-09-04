using UnityEngine;

public class RedLaserScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -10f, 0) * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { 
            GameManager.instnace.GameOver();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
