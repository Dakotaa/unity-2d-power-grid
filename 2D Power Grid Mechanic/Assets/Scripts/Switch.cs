using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : PowerObject {
	private bool activated = false;
	public PowerInput input;
	public PowerOutput output;

	void Start() {
    }

	void Update() {
		if (powered) {
			if (activated) {
				setColour(Color.green);
			} else {
				setColour(Color.red);
			}
		} else {
			setColour(Color.grey);
		}
	}

	void Activate() {
		activated = true;
		powered = input.IsPowered();
		output.SetPowered(powered);
		setColour(Color.green);
	}

	void Deactivate() {
		activated = false;
		powered = false;
		output.SetPowered(powered);
		setColour(Color.gray);
	}

	private void OnMouseDown() {
		if (activated) {
			Deactivate();
		} else {
			Activate();
		}
	}

	void setColour(Color colour) {
		GetComponent<Renderer>().material.color = colour;
	}
}
