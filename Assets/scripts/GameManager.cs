using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager instance {
		get; private set;
	}

	public InputController InputController {
		get; private set;
	}

	void Awake() {
		instance = this;
		InputController = GetComponentInChildren<InputController>();
	}

	void Update() {
	}
}
