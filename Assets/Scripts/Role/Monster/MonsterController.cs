using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : RoleBehaviour{

    public MonsterAnimaiton selfAnimation;

    public MonsterAnimaiton SelfAnimation {
        get {
            if (selfAnimation == null)
            {
                selfAnimation = gameObject.GetComponent<MonsterAnimaiton>();
            }
            return selfAnimation;
        }
    }

    MonsterModel model;

    Vector3 distance;

    bool isAttacking = false;

    bool isDead = false;

    float attackCount = 2f;

    public void monsterAttack() {

        transform.LookAt(PlayerManager.Instance.Player);
       
        SelfAnimation.MonsterAttack();
   
    }

    public void monsterFollow() {
        
        transform.LookAt(PlayerManager.Instance.Player);

        SelfAnimation.MonsterRun(distance.normalized * 0.02f);
      

    }

    public void monsterReduceHP(float reduced) {

        isDead = model.ReduceHP(reduced);

        if (isDead)
        {
            selfAnimation.MonsterDie();
            
        }

    }


    private void Awake()
    {
        model = new MonsterModel();
    }

    private void Update()
    {

        if (!isDead)
        {
            if (isAttacking)
            {
                attackCount -= Time.deltaTime;
                if (attackCount < 0f)
                {
                    attackCount = 2f;
                    isAttacking = false;
                }
            }

            else
            {

                distance = PlayerManager.Instance.Player.position - transform.position;
                if (distance.magnitude < 20f)
                {

                    if (distance.magnitude < 1.2f)
                    {
                        isAttacking = true;
                        monsterAttack();
                    }
                    else
                    {
                        monsterFollow();
                    }
                }
            }
        }
        
        
    }



}
