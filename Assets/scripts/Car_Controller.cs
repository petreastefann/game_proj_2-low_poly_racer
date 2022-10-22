using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Car_Controller : MonoBehaviour {
	public Transform centerOfMass;
	public float motorTorque = 1500f;
	public float maxSteer = 20f;
	public float gravityMultiplier = 1f;
	public Vector3 startPos;

	public float Steer {
		get; set;
	}
	public float Throttle {
		get; set;
	}

	private Rigidbody _rigidbody;
	private Wheel[] wheels;

	private void Awake() {
		startPos = this.transform.position;
	}

	private void Start() {
		wheels = GetComponentsInChildren<Wheel>();
		_rigidbody = GetComponent<Rigidbody>();
		_rigidbody.centerOfMass = centerOfMass.localPosition;
	}

	private void Update() {
		if(Input.GetKeyDown("r")) {
			//transform.Rotate(Vector3.right * 23000 * Time.deltaTime);
			transform.Rotate(0, 0, 180);
		}

		foreach(var wheel in wheels) {
			wheel.SteerAngle = Steer * maxSteer;
			wheel.Torque = Throttle * -motorTorque;     //car input is backwards so i used a negative value 
		}
	}

	private void FixedUpdate() {
		_rigidbody.AddForce(0, -9.81f * gravityMultiplier, 0, ForceMode.Acceleration);      //acceleration = 5 (set by default)
	}
}

/*	last script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_1 : MonoBehaviour {
	public WheelCollider wheelColliderLeftFront, wheelColliderRightFront, wheelColliderLeftBack, wheelColliderRightBack;

	public Transform wheelLeftFront, wheelRightFront, wheelLeftBack, wheelRightBack;
	public Transform centerOfMass;

	public float motorTorque = 1000f;
	public float maxSteer = 20f;

	private Rigidbody _rigidbody;

	void Start() {
		_rigidbody = GetComponent<Rigidbody>();
		_rigidbody.centerOfMass = centerOfMass.localPosition;
	}

	void FixedUpdate() {
		wheelColliderLeftBack.motorTorque = Input.GetAxis("Vertical") * -motorTorque;      //moves backwards so i used a negative value
		wheelColliderRightBack.motorTorque = Input.GetAxis("Vertical") * -motorTorque;
		wheelColliderLeftFront.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
		wheelColliderRightFront.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
	}

	void Update() {
		var pos = Vector3.zero;
		var rot = Quaternion.identity;

		wheelColliderLeftFront.GetWorldPose(out pos, out rot);
		wheelLeftFront.position = pos;
		wheelLeftFront.rotation = rot * Quaternion.Euler(0, 180, 0);

		wheelColliderRightFront.GetWorldPose(out pos, out rot);
		wheelRightFront.position = pos;
		wheelRightFront.rotation = rot;

		wheelColliderLeftBack.GetWorldPose(out pos, out rot);
		wheelLeftBack.position = pos;
		wheelLeftBack.rotation = rot * Quaternion.Euler(0, 180, 0);

		wheelColliderRightBack.GetWorldPose(out pos, out rot);
		wheelRightBack.position = pos;
		wheelRightBack.rotation = rot;
	}
}
*/