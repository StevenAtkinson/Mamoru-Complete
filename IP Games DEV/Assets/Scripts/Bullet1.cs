using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this contols the bullet behaviour
public class Bullet1 : MonoBehaviour
{
    public float speed;
    public float damage;



    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

    }

}

