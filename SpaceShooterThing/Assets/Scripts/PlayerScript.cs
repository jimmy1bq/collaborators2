using UnityEngine;

public class Player : MonoBehaviour
{
    float posY;
    [SerializeField] GameObject PlayerLaser1PreFab;
    [SerializeField] GameObject Explosion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posY = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= 4.9)
        {
            Vector3 comps = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(4.9f, posY, 0);
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x <= -4.9)
        {
            Vector3 comps = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(-4.9f, posY, 0);
        }
        else {
            Vector3 comps = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(comps.x, posY, 0);
        }

        if (Input.GetButtonDown("FireLaser"))
        {
            if (GameManager.instnace.GetScore() >= 100)
            {
                Instantiate(PlayerLaser1PreFab, transform.position, Quaternion.identity);
                Instantiate(PlayerLaser1PreFab, transform.position, Quaternion.identity);
            }
            else { Instantiate(PlayerLaser1PreFab, transform.position, Quaternion.identity);
               
            }    
        }   
    }
}
