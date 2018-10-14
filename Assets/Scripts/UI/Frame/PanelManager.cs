using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{


    public GameObject GetWidget(string widgetName) {

        return UIManager.Instance.GetWidget(transform.name, widgetName);

    }

    public WidgetsBehaviour GetBehaviour(string widgetName) {

        GameObject tmpobj = GetWidget(widgetName);

        if (tmpobj != null)
        {
            return tmpobj.GetComponent<WidgetsBehaviour>();
        }
        return null;
    }


    public void ChildrenRegister() {

        Transform[] allChildren = transform.GetComponentsInChildren<Transform>();

        for (int i = 0; i < allChildren.Length; i++)
        {
            if (allChildren[i].name.EndsWith("_N"))
            {
                allChildren[i].gameObject.AddComponent<WidgetsBehaviour>();
            }
        }
    }


    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void AddButtonListener(string widgetName, UnityAction action) {

        WidgetsBehaviour tmpBehaviour = GetBehaviour(widgetName);

        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddButtonListener(action);
        }

    }

    public void AddInputFieldEndEditListener(string widgetName, UnityAction<string> action) {


        WidgetsBehaviour tmpBehaviour = GetBehaviour(widgetName);

        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddInputFieldEndEditListener(action);
        }

    }

    public void AddInputFieldValueChangedListener(string widgetName, UnityAction<string> action)
    {


        WidgetsBehaviour tmpBehaviour = GetBehaviour(widgetName);

        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddInputFieldValueChangedListener(action);
        }

    }

    public void AddOnDrag(string widgetName, UnityAction<BaseEventData> action) {

        WidgetsBehaviour tmpBehaviour = GetBehaviour(widgetName);

        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddOnDrag(action);
        }

    }

    public void AddBeginDrag(string widgetName, UnityAction<BaseEventData> action)
    {

        WidgetsBehaviour tmpBehaviour = GetBehaviour(widgetName);

        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddBeginDrag(action);
        }

    }

    public void AddEndDrag(string widgetName, UnityAction<BaseEventData> action)
    {

        WidgetsBehaviour tmpBehaviour = GetBehaviour(widgetName);

        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddEndDrag(action);
        }

    }

    public void AddPointClick(string widgetName, UnityAction<BaseEventData> action) {

        WidgetsBehaviour tmpBehaviour = GetBehaviour(widgetName);

        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddPointClick(action);
        }
    }

    public Image GetImage(string widgetName) {
        WidgetsBehaviour tmpBehaviour = GetBehaviour(widgetName);

        if (tmpBehaviour != null)
        {
            return tmpBehaviour.GetImage();
        }
        return null;
    }

    public Slider GetSlider(string widgetName) {
        WidgetsBehaviour tmpBehaviour = GetBehaviour(widgetName);
        if (tmpBehaviour != null)
        {
            return tmpBehaviour.GetSlider();
        }
        return null;

    }

  
}
