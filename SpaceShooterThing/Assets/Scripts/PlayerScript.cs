using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
       Vector3 comps = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        transform.position = new Vector3(
        comps.x + comps.x+ comps.x + comps.x, 
        comps.y+ comps.y + comps.y + comps.y, 0);
      
    }
}
