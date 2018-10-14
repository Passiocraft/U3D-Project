using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMBase{

    public virtual void OnEnter() { }
    public virtual void OnStay() { }
    public virtual void OnExit() { }
}


public class FSMManager {

    FSMBase[] allState;

    #region Initial
    public FSMManager(int stateCount) {
        Initial(stateCount);
    } 

    public void Initial(int stateCount) {
        allState = new FSMBase[stateCount];
    }
    #endregion

    sbyte currentState = -1;

    sbyte stateIndex = -1;

    public void AddState(FSMBase tmpBase)
    {
        if (currentState > allState.Length-1)
        {return;}
        currentState++;
        allState[currentState] = tmpBase;
        
    }

    public void ChangeState(sbyte index) {

        if (index > allState.Length - 1 || index == stateIndex)
        {
            return;
        }
        if (stateIndex != -1)
        {
            allState[stateIndex].OnExit();

        }
        
        stateIndex = index;
        allState[stateIndex].OnEnter();

    }

    public void stay()
    {
        if (stateIndex != -1)
        {
            allState[stateIndex].OnStay();
        }

    }
}