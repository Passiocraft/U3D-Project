using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackJudgment {

    public bool RectAttackJudge(Transform attacker, Transform attacked, float rightDistance, float forwardDistance) {
        Vector3 deltaA = attacked.position - attacker.position;

        float forwardDelta = Vector3.Dot(attacker.forward, deltaA);

        if (forwardDelta > 0 && forwardDelta <= forwardDistance)
        {
            if (Mathf.Abs(Vector3.Dot(attacker.right, deltaA)) < rightDistance) 
            {
                return true;
            }
            

        }
        return false;
    }

    public List<GameObject> RectAttackJudge(Transform attacker, List<GameObject> attacked, float rightDistance, float forwardDistance) {

        List<GameObject> beAttacked = new List<GameObject>();

        Vector3 deltaA;

        float forwardDelta;

        for (int i = 0; i < attacked.Count; i++)
        {
           
            deltaA = attacked[i].transform.position - attacker.position;

            forwardDelta = Vector3.Dot(attacker.forward, deltaA);

            if (forwardDelta > 0 && forwardDelta <= forwardDistance)
            {
                if (Mathf.Abs(Vector3.Dot(attacker.right, deltaA)) < rightDistance)
                {
                    beAttacked.Add(attacked[i]);
                   
                }


            }
        }

        return beAttacked;

    }











    public bool UmbrellaAttack(Transform attacker, Transform attacked, float angle, float radius) {

        Vector3 deltaA = attacked.position - attacker.position;
        float tmpAngle = Mathf.Acos(Vector3.Dot(deltaA.normalized, attacker.forward) * Mathf.Rad2Deg);

        if (tmpAngle < angle * 0.5f && deltaA.magnitude < radius)
        {
            return true;
        }
        return false;
    }

}
