using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterModel {

    private Vector2 attackRange = new Vector2(2f, 5f);   

    public Vector2 AttackRange {

        get { return attackRange; }

        set { attackRange = value; }
    }

    private float hp = 100f;

    public float Hp {

        get { return hp; }
    }

    private float attack = 20f;

    public float Attack {

        get { return attack; }

    }

    
    public bool ReduceHP(float reduced) {

        hp -= reduced;

        if (hp < 0f)
        {
            return true;
        }

        return false;
    }

    private float attackAnimation = 1.0f;

    public float AttackAniamtion {

        get { return attackAnimation; }
    }

    private float dieAnimation = 2.6f;

    public float DieAnimation
    {

        get { return dieAnimation; }
    }


}
