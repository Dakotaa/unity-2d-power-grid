using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : PowerObject {
	private bool activated = false;
	public PowerInput input;
	public PowerOutput output;
	public TextMesh statusIndicator, powerIndicator;
	public AudioSource toggle;

	void Start() {
		toggle = GetComponent<AudioSource>();
	}

	void Update() {}

	public override void Signal() {
		powered = input.IsPowered();

		if (activated) {
			statusIndicator.text = "ON";
			setColour(Color.green);
		} else {
			statusIndicator.text = "OFF";
			setColour(Color.red);
		}

		if (this.powered) {
			powerIndicator.text = "100%\nPOWER";
		} else {
			powerIndicator.text = "0%\nPOWER";
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
