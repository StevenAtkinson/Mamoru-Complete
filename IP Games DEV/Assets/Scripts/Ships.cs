using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ships : MonoBehaviour
{
    public int Score = 0;
    public ShieldHealthBar ShieldBar; 
    public Shield playerShield;
    public Transform SheildIcon;
    public Transform HealthIcon;
    public int PowerUp;
    public shipType shipType;
    protected float health;
    protected Vector2 acceleration;
    protected float bulletSpeed;
    protected float lazerSpeed;
    protected float bulletCoolDown;
    protected float lazerCoolDown;
    protected float bulletLastFired;
    protected float lazerLastFired;
    protected float bulletDamage;
    protected float lazerDamage;
    public Rigidbody2D RB;
    public GameObject bulletPrefab;
    public GameObject lazerPrefab;
    public BossHealthBar bossHealthBar;
    public HealthBar playerHealthBar;


    public enum Direction
    {
        up,
        down,
    }
    [HideInInspector]
    public Direction direction = Direction.up;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        initialiseShip();

    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();

    }

    private void initialiseShip()
    {
        shipData data = GameManager.shipDataDictionary[shipType];
        health = data.health;
        acceleration = data.acceleration;
        bulletSpeed = data.bulletSpeed;
        lazerSpeed = data.lazerSpeed;
        bulletCoolDown = data.bulletCoolDown;
        lazerCoolDown = data.lazerCoolDown;
        bulletDamage = data.bulletDamage;
        lazerDamage = data.lazerDamage;

    }
    protected virtual void TakeInput()
    {

    }

    protected virtual void Shoot()
    {

    }

    protected virtual void Shoot2()
    {

    }

    protected void TakeDamagePlayer(float damage)
    {
       
            FindObjectOfType<AudioManager>().Play("ShipHit");
            playerShield.shieldOff();
            ShieldBar.setInActive();
            health -= damage;
            playerHealthBar.playerHealth = health;
            if (health <= 0)
            {
                Kill();
            }
        
    }

    public void TakeDamageBoss(float damage)
    {
        health -= damage;
        bossHealthBar.bossHealth = health;
        if (health <= 0)
        {
            Kill();
        }
    }
    protected void TakeDamageEnemy(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Kill();
            
        }
    }




    protected void Kill()
    {
        Destroy(this.gameObject);
        FindObjectOfType<AudioManager>().Play("ShipExplosion");
        {
            

            PowerUp = Random.Range(1, 10);
            if (PowerUp == 3)
            {
                Instantiate(SheildIcon, transform.position, SheildIcon.rotation);
            }

            if (PowerUp == 2)
            {
                Instantiate(HealthIcon, transform.position, HealthIcon.rotation);
            }


        }
        
        
    }
   
}
