using UnityEngine;

public class Player : MonoBehaviour
{
    float posY;
    [SerializeField] GameObject PlayerLaser1PreFab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posY = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {//don't use viewport point lol
        Vector3 comps = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(comps.x, posY, 0);

        if (Input.GetButtonDown("FireLaser")){
            Instantiate(PlayerLaser1PreFab, transform.position, Quaternion.identity);
        }
    }
}
