using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Ships
{
    public Transform BulletSpawn;
    public Transform LazerSpawn;
    public Transform BulletSpawn2;
    public Transform LazerSpawn2;




    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();


    }
    // this is the code to define the keys for the player to use to contol the ship.
    // WASD keys move up down left and right and K and L keys fire
    protected override void TakeInput()
    {
        Vector2 velocity = RB.velocity;
        Vector2 direction = transform.up;

        if (Input.GetKey(KeyCode.W))
        {
            velocity.y += acceleration.y * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            velocity.y -= acceleration.y * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x -= acceleration.x * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            velocity.x += acceleration.x * Time.deltaTime;
        }
        RB.velocity = velocity;
       
        if (Input.GetKey(KeyCode.K))
        {
            Shoot();
            
        }
        if (Input.GetKey(KeyCode.L))
        {
            Shoot2();
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    
        // this is the code to take damage when the player collides with either boss or enemy bullets
        if (collision.gameObject.tag == "EnemyBullet")
        {
            TakeDamagePlayer(collision.GetComponent<Bullet1>().damage);
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.tag == "BossBullet")
        {
            TakeDamagePlayer(collision.GetComponent<BossBullet>().damage);

        }
        else if (collision.gameObject.tag == "EnemyLazer")
        {
            TakeDamagePlayer(collision.GetComponent<EnemyLazer>().damage);

        }
        // this turns on the shield when the power up is picked up
        else if (collision.gameObject.tag == "ShieldIcon")
        {

            playerShield.shieldOn();
            ShieldBar.setActive();
        }
        // this adds health to the player when the health power up is picked up
        else if (collision.gameObject.tag == "HealthIcon")
        {
            health += 25;
            playerHealthBar.playerHealth = health;
        }
        
    }
    // this is the cannon fire code 
    protected override void Shoot()
    {
        if (Time.time > bulletLastFired + bulletCoolDown)
        {
            bulletLastFired = Time.time;
            GameObject Bullet = Instantiate(bulletPrefab, BulletSpawn.position, Quaternion.identity);
            Bullet1 b = Bullet.GetComponent<Bullet1>();
            b.damage = bulletDamage;
            b.speed = bulletSpeed;
            FindObjectOfType<AudioManager>().Play("BulletFire");
            StartCoroutine(timer());

            bulletLastFired = Time.time;
            GameObject Bullet2 = Instantiate(bulletPrefab, BulletSpawn2.position, Quaternion.identity);
            Bullet1 c = Bullet.GetComponent<Bullet1>();
            c.damage = bulletDamage;
            c.speed = bulletSpeed;
            FindObjectOfType<AudioManager>().Play("BulletFire");
            StartCoroutine(timer());

            IEnumerator timer()
            {
                yield return new WaitForSeconds(6);
                Destroy(Bullet);

            }
        }
    }
   // this is the lazer fire control 
    protected override void Shoot2()
    {
        if (Time.time > lazerLastFired + lazerCoolDown)
        {
            lazerLastFired = Time.time;
            GameObject Lazer = Instantiate(lazerPrefab, LazerSpawn.position, Quaternion.identity);
            Lazer l = Lazer.GetComponent<Lazer>();
            l.damage = lazerDamage;
            l.speed = lazerSpeed;
            FindObjectOfType<AudioManager>().Play("LazerFire");
            StartCoroutine(timer());

            lazerLastFired = Time.time;
            GameObject Lazer2 = Instantiate(lazerPrefab, LazerSpawn2.position, Quaternion.identity);
            Lazer m = Lazer.GetComponent<Lazer>();
            m.damage = lazerDamage;
            m.speed = lazerSpeed;
            FindObjectOfType<AudioManager>().Play("LazerFire");
            StartCoroutine(timer());

            IEnumerator timer()
            {
                yield return new WaitForSeconds(3);

                Destroy(Lazer);

            }
        }
    }

   
 
  
}
