using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP {


    float blood = 1f;

    Slider hpSlider;

    public HP(Slider slider) {
        hpSlider = slider;
    }

    

    public void ReduceHP(float reduced) {
        
        blood -= reduced;

        hpSlider.value = blood;

       

    }

}
