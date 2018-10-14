using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick
{

    Vector2 originPos;

    public float radius;

    public GameObject target;

    public GameObject Target { set { target = value; } }

    public Transform draggedImage;

    Vector2 deltaPos;

    private bool isDragged = false;

    public JoyStick(GameObject target, Transform draggedImage) {

        this.target = target;
        this.draggedImage = draggedImage;
        radius = 100f;
        originPos = draggedImage.position;
    }
   
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	public void Update () {

        if (isDragged)
        {
            PlayerManager.Instance.Animation.PlayerRun(deltaPos.x, deltaPos.y);
        }
       
    }

    

    public void OnDrag(BaseEventData eventData)
    {
        PointerEventData tmpData = (PointerEventData)eventData;

        isDragged = true;

        deltaPos = tmpData.position - originPos;
       

        if (deltaPos.magnitude < radius)
        {
            draggedImage.position = tmpData.position;
        }
        else
        {
            draggedImage.position = originPos + deltaPos.normalized * radius;
        }

       
     

    }

    public void EndDrag(BaseEventData eventData) {

        draggedImage.position = originPos;

        isDragged = false;
        deltaPos = Vector2.zero;
        PlayerManager.Instance.Animation.PlayerChangeState((sbyte)PlayerAnimation.AnimationEnum.Idle);

    }

   

}
