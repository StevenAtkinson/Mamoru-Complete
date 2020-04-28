using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this script controls behaviours for the boss enemy 
public class BossController : Ships
{
    List<Move> moveSet;
    Move currentMove;
    int moveIndex;
    float moveStartTime;




    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        moveSet = GameManager.moveSetDictionary[shipType];
        currentMove = moveSet[0];

        if (direction == Direction.down)
        {
            acceleration.x *= -1;
            acceleration.y *= -1;
        }

    }
    private void DecideMove()
    {
        if (Time.time > moveStartTime + currentMove.duration)
        {
            moveIndex++;
            if (moveIndex == moveSet.Count)
            {
                moveIndex = 0;
            }
            currentMove = moveSet[moveIndex];
            moveStartTime = Time.time;
        }
    }

    protected override void TakeInput()
    {
        DecideMove();
        Vector2 velocity = RB.velocity;

        if (currentMove.whichKey == KeyCode.W)
        {
            velocity.y += acceleration.y * Time.deltaTime;
        }
        else if (currentMove.whichKey == KeyCode.S)
        {
            velocity.y -= acceleration.y * Time.deltaTime;
        }
        if (currentMove.whichKey == KeyCode.A)
        {
            velocity.x -= acceleration.x * Time.deltaTime;
        }
        else if (currentMove.whichKey == KeyCode.D)
        {
            velocity.x += acceleration.x * Time.deltaTime;
        }
        RB.velocity = velocity;

        Shoot();
        Shoot2();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamageBoss(collision.GetComponent<Bullet1>().damage);
            ScoreCounter.scoreValue += 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Lazer")
        {
            TakeDamageBoss(collision.GetComponent<Lazer>().damage);
            ScoreCounter.scoreValue += 10;
        }
        if (collision.gameObject.tag == "OuterWall")
        {
            Destroy(this);
        }
        if (collision.gameObject.tag == "BottomWall")
        {
            Destroy(this);
        }

    }


    protected override void Shoot()
    {
        if (Time.time > bulletLastFired + bulletCoolDown)
        {
            bulletLastFired = Time.time;
            Vector3 to = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
            GameObject Bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);

            Bullet.transform.rotation = Pointer.LookAt2D(this.transform.position, to);
            Bullet1 b = Bullet.GetComponent<Bullet1>();
            b.damage = bulletDamage;
            b.speed = bulletSpeed;
            StartCoroutine(timer());
            FindObjectOfType<AudioManager>().Play("BulletFire");
            IEnumerator timer()
            {
                yield return new WaitForSeconds(3);
                Destroy(Bullet);

            }
        }
    }
   
}