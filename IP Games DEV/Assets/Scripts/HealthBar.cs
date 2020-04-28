using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
// This controls the player health bar
public class HealthBar : MonoBehaviour
{
    public Slider PHSlider;
    public Text Health;
    public float playerHealth;


    // Start is called before the first frame update

    private void Start()
    {

        playerHealth = GameManager.shipDataDictionary[shipType.Player].health;
    }

    public void Update()
    {
        
        PHSlider.value = playerHealth;
        Health.text = "Health: " + playerHealth;
    }
    


}