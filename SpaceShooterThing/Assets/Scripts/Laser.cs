using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float LaserSpeed = 15.0f;
    [SerializeField] GameObject Explosion;
    bool gainedExplosionPowerup = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {   if(transform.position.y >= 10.0f)
        {
            Destroy(this.gameObject);
        }
        if(GameManager.instnace.GetScore() >= 100)
        {
           gainedExplosionPowerup=true;
        }
        transform.position += new Vector3(0, LaserSpeed ,0) * Time.deltaTime;
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gainedExplosionPowerup && collision.gameObject.tag != "RedLaser")
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
    }

    }
      

}
