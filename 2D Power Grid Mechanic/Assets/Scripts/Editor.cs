using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor : MonoBehaviour {
	private WireCreator wireCreator;
	public GameObject ghostWire, ghostPowerSource, ghostSimpleNode, ghostSwitch;
	public GameObject powerSource, simpleNode, powerSwitch;
	private GameObject cursorGhost;
	private int mode = 1;

    void Start() {
		wireCreator = FindObjectOfType(typeof(WireCreator)) as WireCreator;
	}

    void Update() {

		if (Input.GetMouseButtonDown(0)) {
			print("click");
			if (mode > 2) {
				print("valid mode");
				CreateObject();
			}
		}

		if (Input.GetKeyDown("1")) {
			SwitchMode(1);
		} else if (Input.GetKeyDown("2")) {
			SwitchMode(2);
		} else if (Input.GetKeyDown("3")) {
			SwitchMode(3);
		} else if (Input.GetKeyDown("4")) {
			SwitchMode(4);
		} else if (Input.GetKeyDown("5")) {
			SwitchMode(5);
		}

		if (mode > 2) {
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			pos.z = 0.0f;
			cursorGhost.transform.position = pos;
		}

	}

	private void SwitchMode(int mode) {
		if (mode > 0 && mode <= 5) {
			Destroy(cursorGhost);
			this.mode = mode;
			if (mode <= 2) {
				Cursor.visible = true;
			} else {
				Cursor.visible = false;
				switch(mode) {
					case 3:
						cursorGhost = Instantiate(ghostPowerSource);
						break;
					case 4:
						cursorGhost = Instantiate(ghostSimpleNode);
						break;
					case 5:
						cursorGhost = Instantiate(ghostSwitch);
						break;
				}
			}
		}
	}

	private void CreateObject() {
		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Quaternion rot = new Quaternion(90.0f, 0.0f, 0.0f, -90.0f);
		pos.z = 0.0f;
		switch (mode) {
			case 3:
				Instantiate(powerSource, pos, rot);
				break;
			case 4:
				Instantiate(simpleNode, pos, rot);
				break;
			case 5:
				Instantiate(powerSwitch, pos, rot);
				break;
		}
	}

	public int GetMode() {
		return mode;
	}
}
