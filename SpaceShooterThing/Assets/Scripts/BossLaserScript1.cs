using UnityEngine;

public class BossLaserScript1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10.0f)
        {
            Destroy(this.gameObject);
        }
        else
        { transform.position += new Vector3(0, -3f ,0 ) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D otherComp) {
        if (otherComp.gameObject.tag == "Player")
        {
            GameManager.instnace.GameOver();
            Destroy(this.gameObject);
            Destroy(otherComp.gameObject);
        }
    }
}
