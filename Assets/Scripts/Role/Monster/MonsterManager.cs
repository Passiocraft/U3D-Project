using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {

    public static MonsterManager Instance;

    public List<GameObject> AllMonsters {get; private set;}

    public List<MonsterController> AllMonsterController { get; private set; }

   // public List<MonsterModel> AllModel { get; private set; }


    private void Initial() {

        Transform[] tmpAllParents = transform.GetComponentsInChildren<Transform>();
        
        List<Transform> allParents = new List<Transform>();

        AllMonsters = new List<GameObject>();
        AllMonsterController = new List<MonsterController>();

        for (int i = 0; i < tmpAllParents.Length; i++)
        {
            if (tmpAllParents[i].name.EndsWith("_"))
            {
                allParents.Add(tmpAllParents[i]);
            }
        }
        string prefabPath = "ZombieCharacters/ZombiePrefabs/Zombie";

        for (int i = 0; i < allParents.Count; i++)
        {
       
            GameObject tmpObj = MonsterFactory(prefabPath, allParents[i]);
            AllMonsters.Add(tmpObj);
        }

    }

    public GameObject MonsterFactory(string path, Transform monsterParent)
    {

        Object tmpObj = Resources.Load(path);

        GameObject tmpMonster = GameObject.Instantiate(tmpObj) as GameObject;

        tmpMonster.transform.SetParent(monsterParent, false);

        MonsterController tmpMonsterController = tmpMonster.AddComponent<MonsterController>();

        tmpMonster.AddComponent<MonsterAnimaiton>();

        AllMonsterController.Add(tmpMonsterController);

        tmpMonster.SetActive(true);


        return tmpMonster;
    }


    public void MonsterReduceHP(List<GameObject> monsters, float reduced) {

        for (int i = 0; i < monsters.Count; i++)
        {
            MonsterController tmpController = monsters[i].transform.GetComponent<MonsterController>();

            tmpController.monsterReduceHP(reduced);
        }

    }

    private void Awake()
    {
        Instance = this;

        Initial();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}



