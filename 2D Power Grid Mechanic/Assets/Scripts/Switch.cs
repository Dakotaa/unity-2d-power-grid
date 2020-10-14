using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : PowerObject {
	private bool activated = false;
	public PowerInput input;
	public PowerOutput output;
	public AudioSource toggle;

	void Start() {
		toggle = GetComponent<AudioSource>();
		setColour(Color.grey);
	}

	void Update() {}

	public override void Signal() {
		powered = input.IsPowered();

		if (activated) {
			setColour(Color.green);
		} else {
			setColour(Color.red);
		}

		if (this.powered) {
		} else {
			setColour(Color.grey);
		}

		output.SetPowered(powered && activated);
		output.Signal();
	}

	void Activate() {
		activated = true;
		toggle.Play();
		Signal();
	}

	void Deactivate() {
		activated = false;
		toggle.Play();
		Signal();
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
