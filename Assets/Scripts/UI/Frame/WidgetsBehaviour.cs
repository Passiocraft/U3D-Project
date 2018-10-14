using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WidgetsBehaviour : MonoBehaviour
{


    public void AddButtonListener(UnityAction action)
    {
        Button tmp = transform.GetComponent<Button>();
        if (tmp != null)
        {
            tmp.onClick.AddListener(action);
        }
    }

    public void AddSliderListener(UnityAction<float> action)
    {
        Slider tmp = transform.GetComponent<Slider>();
        if (tmp != null)
        {
            tmp.onValueChanged.AddListener(action);
        }
    }

    public Slider GetSlider() {

        return transform.GetComponent<Slider>();
    }

    public void AddInputFieldEndEditListener(UnityAction<string> action)
    {
        InputField tmp = transform.GetComponent<InputField>();
        if (tmp != null)
        {
            tmp.onEndEdit.AddListener(action);
        }
    }

    public void AddInputFieldValueChangedListener(UnityAction<string> action)
    {
        InputField tmp = transform.GetComponent<InputField>();
        if (tmp != null)
        {
            tmp.onValueChanged.AddListener(action);
        }
    }

    public void AddOnDrag(UnityAction<BaseEventData> action) {

        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();

        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry entry = new EventTrigger.Entry();

        entry.eventID = EventTriggerType.Drag;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        trigger.triggers.Add(entry);
    }

    public void AddBeginDrag(UnityAction<BaseEventData> action) {

        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();

        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry entry = new EventTrigger.Entry();

        entry.eventID = EventTriggerType.BeginDrag;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        trigger.triggers.Add(entry);

    }

    public void AddEndDrag(UnityAction<BaseEventData> action)
    {

        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();

        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry entry = new EventTrigger.Entry();

        entry.eventID = EventTriggerType.EndDrag;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        trigger.triggers.Add(entry);

    }

    public void AddPointClick(UnityAction<BaseEventData> action) {

        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();

        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry entry = new EventTrigger.Entry();

        entry.eventID = EventTriggerType.PointerClick;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        trigger.triggers.Add(entry);

    }

    public Image GetImage() {

        Image tmpImage = transform.GetComponent<Image>();

        if (tmpImage != null)
        {
            return tmpImage;
        }

        return null; 
    }


    private void Awake()
    {
      
        PanelManager pm = transform.GetComponentInParent<PanelManager>();
        

        UIManager.Instance.RegisterWidgets(pm.name, transform.name, gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
}
