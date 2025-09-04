using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyBossScript : MonoBehaviour
{
    [SerializeField] float Bossspeed = 2.0f;
    [SerializeField] GameObject BossLaser;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Benemies;
    [SerializeField]int TotalHp = 1000;
    [SerializeField] int Hp = 1000;
    public static bool BossAlive = false;
    bool LaserCalled = true;
    bool secondPhyaze = true;
    bool ThirdPhyaze = true;

    void Start()
    {
     BossAlive = true;
    }
    void InvokedFirstPhase() {
        fireLaser(new Vector3(transform.position.x,transform.position.y,0));
    }

 
    void InvokedSecondPhase()
    {
        fireLaser(new Vector3(transform.position.x-3.5f, transform.position.y, 0));
        fireLaser(new Vector3(transform.position.x+3.5f, transform.position.y, 0));
    }
    void ThirdPhase() {
        float xmin = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0, 0)).x;
        float xmax = Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0, 0)).x;
        float randomx = UnityEngine.Random.Range(xmin, xmax);
        Instantiate(Benemies, new Vector3(randomx, transform.position.y, 0), Quaternion.identity);
    }
  


    void fireLaser(Vector3 pos)
    { 
       Instantiate(BossLaser, pos , Quaternion.Euler(Quaternion.identity.x, 0 ,Quaternion.identity.z));
    }
    void Update()
    {   
        Debug.Log("Is: " + LaserCalled);

        if (transform.position.y > 7.2f)
        {
            transform.position -= new Vector3(0, Bossspeed, 0) * Time.deltaTime;
        }

        if (LaserCalled)
        {
            LaserCalled = false;
            InvokeRepeating("InvokedFirstPhase", 0, 5);
        }
        
        if (Hp < (TotalHp / 2) && secondPhyaze)
        {
            secondPhyaze = false;
            InvokeRepeating("InvokedSecondPhase", 0, 3);
        }
        if (Hp < (TotalHp / 3) && ThirdPhyaze)
        {
            ThirdPhyaze = false;
            InvokeRepeating("ThirdPhase", 0, 2);
        }

    }

    void OnTriggerEnter2D(Collider2D otherComp) {
        if (otherComp.gameObject.tag == "PlayerLaser" || otherComp.gameObject.tag == "PlayerExplosion" ) {
            Debug.Log(otherComp.tag);
            Hp -= 1;
            Destroy(otherComp.gameObject);
        }
        if (Hp <= 0) {
            GameManager.instnace.AddScore(1000);
            BossAlive = false;
            Destroy(gameObject);
        }
    }
 

}
