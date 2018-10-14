using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    private Transform target;

    public Vector3 distance = new Vector3(0, 1.9f, -3.5f);

    public Vector3 velocity = Vector3.one;

    public float smoothTime = 0.25f;

	// Use this for initialization
	void Start () {
        target = PlayerManager.Instance.Player;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + distance, ref velocity, smoothTime);
	}
}
