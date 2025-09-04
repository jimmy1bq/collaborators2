using UnityEngine;

public class EnemyBlackScript : MonoBehaviour
{
    [SerializeField] float EnemyBlackSpeed = 5.0f;
    [SerializeField] GameManager gameManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   if (transform.position.y <= -9.5f)
        {
            Destroy(this.gameObject);
        }
        transform.position += new Vector3(0, -EnemyBlackSpeed ,0) * Time.deltaTime;
       
    }
    private void OnTriggerEnter2D(Collider2D otherComp) {
        if (otherComp.gameObject.tag == "Player") { 
        GameManager.instnace.GameOver();
        Destroy(gameObject);
        Destroy(otherComp.gameObject);
    }
        if (otherComp.gameObject.tag == "PlayerLaser" || otherComp.gameObject.tag == "PlayerExplosion")
        {

            Debug.Log(otherComp.gameObject.tag);
            GameManager.instnace.AddScore(20);
            Destroy(gameObject);
            Destroy(otherComp.gameObject);
        }

    }
}
