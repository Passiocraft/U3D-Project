using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager Instance;

    public Transform Player { get { return Animation.transform; } }

    public PlayerAnimation Animation { get; private set; }

    public PlayerModel model;


    private void Awake()
    {
        Instance = this;

        Initial();

    }

    public void Initial() {

        Object tmpObj = Resources.Load("AncientWarrior/Prefabs/AncientWarrior");

        GameObject playerObj = GameObject.Instantiate(tmpObj) as GameObject;

        this.Animation = playerObj.AddComponent <PlayerAnimation>();

        playerObj.transform.SetParent(transform, false);

        playerObj.SetActive(true);

        model = new PlayerModel();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   

    public void ReduceHP(float reduced) {

        model.HP -= reduced;

        GameObject tmpObj = UIManager.Instance.GetWidget("HUD", "HP_N");

        HUD hud = tmpObj.GetComponentInParent<HUD>();

        hud.ReduceHP(reduced / 100f);

    }



}
