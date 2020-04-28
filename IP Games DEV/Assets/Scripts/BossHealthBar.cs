using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
// this script controls the boss health bar
public class BossHealthBar : MonoBehaviour
{
    public Slider BossSlider;
    public float bossHealth;
    public Text Health;


    // Start is called before the first frame update

    private void Start()
    {
        GetComponent<Text>();
        bossHealth = GameManager.shipDataDictionary[shipType.Boss].health;
    }

    public void Update()
    {

        BossSlider.value = bossHealth;
        Health.text = "Boss Health: " + bossHealth;
    }


   


}