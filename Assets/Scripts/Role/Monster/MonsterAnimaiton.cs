using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterAnimaiton : RoleBehaviour
{

    public class Idle : FSMBase
    {

        Animator animator;

        public Idle(Animator tmpAnimator)
        {
            animator = tmpAnimator;
        }
        public override void OnEnter()
        {
            //base.OnEnter();
            animator.SetInteger("Index", 1);
        }

    }

    public class Die : FSMBase {

        Animator animator;
        float timeCount = 0f;
        public Die(Animator tmpAnimator)
        {
            animator = tmpAnimator;
        }
        public override void OnEnter()
        {
            //base.OnEnter();
            animator.SetInteger("Index", 4);
        }
        public override void OnStay()
        {
            
        }

    }

    public class Run : FSMBase
    {

        Animator animator;

        CharacterController characterController;

        public Run(Animator tmpAnimator, CharacterController tmpCharacterController)
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


        }

    }

    public class Attack : FSMBase
    {

        UnityAction<sbyte> callBack;
        float timeCount = 0;

        PlayerController player;
        Animator animator;

        public Attack(Animator tmpAnimator, UnityAction<sbyte> tmpCallBack)
        {
            animator = tmpAnimator;
            callBack = tmpCallBack;

        }
        public override void OnEnter()
        {

            animator.SetInteger("Index", 3);
        }


        public override void OnStay()
        {

            timeCount += Time.deltaTime;

            if (timeCount > 1f)
            {
                callBack((sbyte)AnimationEnum.Idle);
            }

        }

        public override void OnExit()
        {
            //base.OnExit();

            timeCount = 0f;

        }


    }

    Animator animator;

    CharacterController characterController;

    AttackJudgment attackJudgment;

    MonsterModel model;

    float dieTimeCount;

    float attackTimeCount;

    bool isDead = false;

    bool isAttack = false;

    private void Start()
    {
        base.Initial();
        animator = transform.GetComponent<Animator>();
        characterController = transform.GetComponent<CharacterController>();

        attackJudgment = new AttackJudgment();

        model = new MonsterModel();

        Idle tmpIdle = new Idle(animator);
        fsm.AddState(tmpIdle);

        Run tmpRun = new Run(animator, characterController);
        fsm.AddState(tmpRun);

        Attack tmpAttack = new Attack(animator, MonsterChangeState);
        fsm.AddState(tmpAttack);

        Die tmpDie = new Die(animator);
        fsm.AddState(tmpDie);

        dieTimeCount = model.DieAnimation;

        attackTimeCount = model.AttackAniamtion;
    }

    public void MonsterChangeState(sbyte state)
    {

        ChangeState(state);

    }

    public void MonsterAttack() {

        MonsterChangeState((sbyte)RoleBehaviour.AnimationEnum.Attack);

        isAttack = true;
    }

    

    public void MonsterDie() {

        MonsterChangeState((sbyte)RoleBehaviour.AnimationEnum.Die);

        isDead = true;
    }

    public void MonsterRun(Vector3 speed) {

        MonsterChangeState((sbyte)RoleBehaviour.AnimationEnum.Run);
        Move(speed);
    }

      

    void Update () {
        if (isDead)
        {
            dieTimeCount -= Time.deltaTime;

            if (dieTimeCount < 0f)
            {
                gameObject.SetActive(false);
            }

        }
        else {

            if (isAttack)
            {
                attackTimeCount -= Time.deltaTime;

                if (attackTimeCount < 0f)
                {
                    if (attackJudgment.RectAttackJudge(transform, PlayerManager.Instance.Player, model.AttackRange.x, model.AttackRange.y))
                    {
                        isAttack = false;
                        PlayerManager.Instance.ReduceHP(model.Attack);
                    }
                }
            }

        }
	}
}
