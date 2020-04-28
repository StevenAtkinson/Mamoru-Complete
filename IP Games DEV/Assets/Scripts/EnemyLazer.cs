using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLazer : MonoBehaviour
{
    public float speed;
    public float damage;



    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

    }
}
