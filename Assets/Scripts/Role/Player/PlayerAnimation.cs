using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerAnimation : RoleBehaviour {


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

    PlayerModel model;

    private void Start()
    {
        base.Initial();
        animator = transform.GetComponent<Animator>();
        characterController = transform.GetComponent<CharacterController>();

        Idle tmpIdle = new Idle(animator);
        fsm.AddState(tmpIdle);

        Run tmpRun = new Run(animator, characterController);
        fsm.AddState(tmpRun);

        Attack tmpAttack = new Attack(animator, PlayerChangeState);
        fsm.AddState(tmpAttack);

        attackJudgment = new AttackJudgment();

        model = new PlayerModel();
    }

    public void PlayerChangeState(sbyte state) {

        ChangeState(state);

    }

    public void PlayerAttack() {

        ChangeState((sbyte)AnimationEnum.Attack);

        StartCoroutine(JudgmentDelay());
    }

    public void PlayerAttack(BaseEventData tmpData)
    {
        ChangeState((sbyte)AnimationEnum.Attack);

        StartCoroutine(JudgmentDelay());
    }

    IEnumerator JudgmentDelay()
    {
        yield return new WaitForSeconds(model.AttackAniamtion);
        List<GameObject> monsterAttacked = attackJudgment.RectAttackJudge(transform, MonsterManager.Instance.AllMonsters, model.AttackRange.x, model.AttackRange.y);
        MonsterManager.Instance.MonsterReduceHP(monsterAttacked, model.Attack);
    }

    public void PlayerIdle() {

        ChangeState((sbyte)AnimationEnum.Idle);

    }

    public void PlayerRun(float x, float y) {

        ChangeState((sbyte)AnimationEnum.Run);

        float radius = Mathf.Sqrt(x*x + y*y);
        float speed = model.Speed;

        float rotationAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        PlayerRotate(rotationAngle);
        
        Move(transform.forward * Time.deltaTime * radius * speed);
    }

  

    private void PlayerRotate(float angle) {

        Vector3 tmpAngle = transform.localEulerAngles;
        tmpAngle.y = 90 - angle;
        transform.localEulerAngles = tmpAngle;

    }
}
