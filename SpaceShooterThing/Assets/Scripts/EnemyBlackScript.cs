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
    {
        transform.position += new Vector3(0, -EnemyBlackSpeed ,0) * Time.deltaTime;
       
    }
    private void OnTriggerEnter2D(Collider2D otherComp) {
        if (otherComp.gameObject.tag == "Player")
        {
            GameManager.instnace.GameOver();
        }
        else
        {
            GameManager.instnace.AddScore(20);
        }
        Destroy(gameObject);
        Destroy(otherComp.gameObject);
    }
}
