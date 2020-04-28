using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this script controls the shield 
public class Shield : MonoBehaviour
{
    public GameObject shield;
    public bool shieldActive;



    // Start is called before the first frame update
    void Start()
    {
        shieldActive = false;
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    // if hit by an enemy bullet shield is turned off 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);   
            shieldOff();
            
        }
        else if (collision.gameObject.tag == "BossBullet")
        {
            Destroy(collision.gameObject);
                shieldOff();
        }
    }
    public void shieldOn()
    {
        shield.SetActive(true);
        shieldActive = true;
    }
    public void shieldOff()
    {
        FindObjectOfType<AudioManager>().Play("ShieldOff");
        shield.SetActive(false);
        shieldActive = false;
    }


    public bool ShieldActive
    {
        get
        {
            return shieldActive;
        }
        set
        {
            shieldActive = value;
        }
    }
}
