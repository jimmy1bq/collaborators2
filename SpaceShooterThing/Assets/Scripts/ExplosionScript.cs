using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { if (transform.localScale.x > 10.0f && transform.localScale.y > 10.0f)
        {
            Destroy(this.gameObject);
        }
        transform.position += new Vector3(0, 0.1f, 0);
        transform.localScale += new Vector3(0.05f, 0.05f, 0);
      
    }
   
}

