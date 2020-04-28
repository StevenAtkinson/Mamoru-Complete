using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().Play("HealthPowerUp");
        }
        if (other.gameObject.tag == "Walls")
        {
            Destroy(this.gameObject);
        }
    }
}
