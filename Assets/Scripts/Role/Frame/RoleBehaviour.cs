using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class RoleBehaviour : MonoBehaviour {

    protected FSMManager fsm;

    CharacterController characterController;

    public AttackJudgment attackJudgment;

    public static RoleBehaviour Instance;

    private Transform player;

    public Transform Player
    {
        get
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }
            return player;
        }
    }

    public enum AnimationEnum
    {
        Idle,
        Run,
        Attack,
        Die,
        Max
    }

    public void SimpleMove(Vector3 speed) {

        characterController.SimpleMove(speed);
        
    }

    public void Move(Vector3 speed)
    {
        characterController.Move(speed);
    }

    //public void BeAttackedByPlayer() {

    //    for (int i = 0; i < allMonster.Count; i++)
    //    {
    //        MonsterController monsterController = allMonster[i];

    //        if (attackJudgment.RectAttackJudge(player, monsterController.transform,10f, 10f))
    //        {

    //        }
    //    }

    //}

    public virtual void ChangeState(sbyte state) {

        fsm.ChangeState(state);

    }

    //List<MonsterController> allMonster;

    //public GameObject MonsterFactory(string path, Transform monsterParent) {

    //    Object tmpObj = Resources.Load(path);
    //    GameObject tmpMonster = GameObject.Instantiate(tmpObj) as GameObject;

    //    tmpMonster.transform.SetParent(monsterParent, false);

    //    MonsterController tmpMonsterController = tmpMonster.AddComponent<MonsterController>();

    //    allMonster.Add(tmpMonsterController);

    //    return tmpMonster;

    //}


    public virtual void Initial() {

        fsm = new FSMManager((int)AnimationEnum.Max);

        characterController = transform.GetComponent<CharacterController>();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (fsm != null)
        {
            fsm.stay();
        }

	}

    private void Awake()
    {
        Instance = this;
        //allMonster = new List<MonsterController>();
        attackJudgment = new AttackJudgment();
    }
}
