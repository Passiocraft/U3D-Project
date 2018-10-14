using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;

    public Transform mainCanvas;

    public Transform MainCanvas { get { return mainCanvas; } set { mainCanvas = value; } }


    Dictionary<string, Dictionary<string, GameObject>> allWidgets;

    public void RegisterWidgets(string panelName, string widgetName, GameObject obj) {

        if (!allWidgets.ContainsKey(panelName))
        {
            allWidgets[panelName] = new Dictionary<string, GameObject>();
        }

        allWidgets[panelName].Add(widgetName, obj);

    }

    public GameObject GetWidget(string panelName, string widgetName) {

        if (allWidgets.ContainsKey(panelName))
        {
            return allWidgets[panelName][widgetName];
        }

        return null;
    }




    private void Awake()
    {
        Instance = this;
        allWidgets = new Dictionary<string, Dictionary<string, GameObject>>();
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas").transform;
    }


    void Start () {
		
	}
	
	
	void Update () {
		
	}
}
