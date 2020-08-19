using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public Transform leftBound;
	public Transform rightBound;

	public float smoothDampTime = 0.15f;
	private Vector3 smoothDampVelocity = Vector3.zero;

	private float camWidth, camHeight, minX, maxX;


	// Use this for initialization
	void Start () {
		camHeight = Camera.main.orthographicSize * 2;
		camWidth = camHeight * Camera.main.aspect;

		float rightBoundWidth = rightBound.GetComponentInChildren< SpriteRenderer >().bounds.size.x / 2;
		float leftBoundWidth = leftBound.GetComponentInChildren< SpriteRenderer >().bounds.size.x / 2;

		minX = leftBound.position.x + leftBoundWidth + (camWidth / 2);
		maxX = rightBound.position.x - rightBoundWidth - (camWidth / 2);
	}
	
	// Update is called once per frame
	void Update () {
		if (target)
        {
			float targetX = Mathf.Max(minX, Mathf.Min(maxX, target.position.x));
			float x = Mathf.SmoothDamp(transform.position.x, targetX, ref smoothDampVelocity.x, smoothDampTime);
			transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
	}
}
