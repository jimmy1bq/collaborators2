using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Player script has Joined.");
    }
    // Update is called once per frame
    void Update()
    {
       Vector3 comps = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        transform.position = new Vector3(
        comps.x, 
        comps.y, 0);
       Debug.Log(comps.x);
        Debug.Log(comps.y);
    }
}
