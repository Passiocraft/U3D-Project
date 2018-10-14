using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manlipulation : PanelManager {

    public GameObject player;



    JoyStick joyStick;

    private void Awake()
    {
        ChildrenRegister();
    }

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        AddJoyStick();
        AddAttack();
    }
	
	// Update is called once per frame
	void Update () {

     

        if (joyStick != null)
        {
            joyStick.Update();
        }

	}


    public void AddJoyStick() {

        GameObject draggedImage = GetWidget("JoyStick_N");
        joyStick = new JoyStick(player, draggedImage.transform);
        AddOnDrag("JoyStick_N", joyStick.OnDrag);
        AddEndDrag("JoyStick_N", joyStick.EndDrag);
        
    }

    public void AddAttack() {
      
        AddPointClick("Attack_N", PlayerManager.Instance.Animation.PlayerAttack);
        
    }
}
