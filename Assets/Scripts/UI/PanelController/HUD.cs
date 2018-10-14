using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : PanelManager
{
    public HP hp;


    private void Awake()
    {
        ChildrenRegister();
    }



    // Use this for initialization
    void Start () {

        AddHPEvent();

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void AddHPEvent() {

       
        Slider hpSlider = GetSlider("HP_N");

        hp = new HP(hpSlider);


    }

    public void ReduceHP(float reduced) {

        hp.ReduceHP(reduced);

    }
}
