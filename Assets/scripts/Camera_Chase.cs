using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Chase : MonoBehaviour {
	public Transform cameraPosition;
	public float smoothSpeed = 10;
	public Vector3 dist;
	public Transform positionToLookAt;

	private void FixedUpdate() {
		Vector3 sPos = Vector3.Lerp(transform.position, cameraPosition.position + dist, smoothSpeed * Time.deltaTime);
		transform.position = sPos;
		transform.LookAt(positionToLookAt.position);
	}

}
