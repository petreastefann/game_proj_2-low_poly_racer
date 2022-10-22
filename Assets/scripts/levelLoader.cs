using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour {
	private void Update() {
		if(Input.GetMouseButton(0)) {
			LoadNextLevel();
		}
	}
	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}
}
