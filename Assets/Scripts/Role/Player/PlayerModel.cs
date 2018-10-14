using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel {

    private float hp = 100f;

    public float HP{ get{ return hp;} set { hp = value; } }

    private float attack = 60f;

    public float Attack { get { return attack; } }

    private Vector2 attackRange = new Vector2(1f, 2f);

    public Vector2 AttackRange { get { return attackRange; } }

    private float attackAnimation = 0.8f;

    public float AttackAniamtion
    {

        get { return attackAnimation; }
    }

    private float speed = 0.1f;

    public float Speed
    {

        get { return speed; }
    }

}
