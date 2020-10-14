using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentGhost : MonoBehaviour {
	private Editor editor;

	void Start() {
		editor = FindObjectOfType(typeof(Editor)) as Editor;
	}

	void Update() { }

	private void OnCollisionStay(Collision collision) {
		if (editor.GetMode() > 2) {
			editor.SetColliding(true);
			print("colliding");
		}
	}

	private void OnCollisionExit(Collision collision) {
		if (editor.GetMode() > 2) {
			editor.SetColliding(false);
			print("not colliding");
		}
	}

}