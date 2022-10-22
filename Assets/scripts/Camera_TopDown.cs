using UnityEngine;

public class Camera_TopDown : MonoBehaviour {
	public Transform target;
	public float smoothSpeed = 1f;
	public Vector3 offset;
	public Vector3 eulerRotation;

	private void Start() {
		transform.eulerAngles = eulerRotation;
	}

	void FixedUpdate() {
		updateCamPos();
	}

	public void updateCamPos() {
		if(target == null)
			return;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;
	}
}
