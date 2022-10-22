using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {
	public bool steer;
	public bool power;

	public float SteerAngle {
		get; set;
	}

	public float Torque {
		get; set;
	}

	private WheelCollider wheelCollider;
	private Transform wheelTransform;

	void Start() {
		wheelCollider = GetComponentInChildren<WheelCollider>();
		wheelTransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();
	}

	void Update() {
		wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
		wheelTransform.position = pos;
		wheelTransform.rotation = rot;
	}

	void FixedUpdate() {
		if(steer) {
			wheelCollider.steerAngle = SteerAngle;
		}

		if(power) {
			wheelCollider.motorTorque = Torque;
		}
	}
}
