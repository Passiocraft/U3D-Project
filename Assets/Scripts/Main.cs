using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public static Main Instance;

    public Transform player;

    public Transform Monster;

    private void Awake()
    {
        Instance = this;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        player.gameObject.AddComponent<PlayerManager>();

        Monster = GameObject.FindGameObjectWithTag("Monsters").transform;

        Monster.gameObject.AddComponent<MonsterManager>();

        Camera.main.gameObject.AddComponent<CameraManager>();

        gameObject.AddComponent<UIManager>();



        DontDestroyOnLoad(gameObject);

    
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
