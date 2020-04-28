using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShieldHealthBar : MonoBehaviour
{
    public Slider ShieldSlider;
    public Text shieldText;


    // Start is called before the first frame update

    private void Start()
    {

        ShieldSlider.value = 0;

    }

    public void setActive()
    {
       ShieldSlider.value = 4;
       shieldText.text = "Shield:ON";
    }
    public void setInActive()
    {
        ShieldSlider.value = 0;
        shieldText.text = "Shield:OFF";
    }



    public void Update()
    {
     

    }


}