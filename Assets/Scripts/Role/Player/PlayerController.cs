using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerIdle : FSMBase
{

    Animator animator;

    public PlayerIdle(Animator tmpAnimator)
    {
        animator = tmpAnimator;
    }
    public override void OnEnter()
    {
        //base.OnEnter();
        animator.SetInteger("Index", 1);
    }

}

public class PlayerRun : FSMBase
{

    Animator animator;

    CharacterController characterController;

    public PlayerRun(Animator tmpAnimator, CharacterController tmpCharacterController)
    {
        animator = tmpAnimator;
        characterController = tmpCharacterController;
    }
    public override void OnEnter()
    {
        //base.OnEnter();
        animator.SetInteger("Index", 2);
       
    }
    public override void OnStay()
    {
        //base.OnExit();
        
        characterController.Move(Vector3.forward * 0.1f);
    }

}



public class PlayerAttack : FSMBase
{
    float timeCount = 0;
    bool isPlaySE = false;
    PlayerController player;
    Animator animator;

    public PlayerAttack(Animator tmpAnimator, PlayerController player)
    {
        animator = tmpAnimator;
        isPlaySE = false;
        timeCount = 0;
        this.player = player;
    }
    public override void OnEnter()
    {
        //base.OnEnter();
        animator.SetInteger("Index", 3);
    }


    public override void OnStay()
    {
        //base.OnStay();
        timeCount += Time.deltaTime;
        if (timeCount > 0.4f && !isPlaySE)
        {
      
            isPlaySE = true;
        }
        else if (timeCount > 1.5f)
        {
            player.ChangeState((sbyte)PlayerController.AnimationEnum.Idle);
        }
    }

    public override void OnExit()
    {
        //base.OnExit();
        isPlaySE = false;
        timeCount = 0f;
    }


}




public class PlayerController : MonoBehaviour
{

    FSMManager fm;

    public enum AnimationEnum
    {
        Idle,
        Run,
        Attack,
        Max
    }

    public void ChangeState(sbyte state)
    {
        fm.ChangeState(state);

    }

    // Use this for initialization
    void Start()
    {
        fm = new FSMManager((int)AnimationEnum.Max);
        Animator animator = GetComponent<Animator>();
        CharacterController characterController = GetComponent<CharacterController>(); ;
        PlayerIdle tmpIdle = new PlayerIdle(animator);
        fm.AddState(tmpIdle);
        PlayerRun tmpRun = new PlayerRun(animator, characterController);
        fm.AddState(tmpRun);
        PlayerAttack tmpAttack = new PlayerAttack(animator, this);
        fm.AddState(tmpAttack);
    }

    // Update is called once per frame
    void Update()
    {
        fm.stay();
        if (Input.GetKeyDown(KeyCode.W))
        {
            fm.ChangeState((sbyte)AnimationEnum.Run);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            fm.ChangeState((sbyte)AnimationEnum.Attack);
        }
    }
}
