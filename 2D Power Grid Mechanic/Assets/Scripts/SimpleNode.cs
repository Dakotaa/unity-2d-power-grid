using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleNode : PowerObject {

    public PowerInput[] inputs;
    public GameObject box;

    void Start() {}
    void Update() {}

	public override void Signal() {
		print("Node signalled");
		powered = false;
		foreach (PowerInput input in inputs) {
			if (input.IsPowered()) {
				powered = true;
			}
		}
		if (powered) {
			SetColour(Color.green);
		} else {
			SetColour(Color.red);
		}
	}

	void SetColour(Color colour) {
        box.GetComponent<Renderer>().material.color = colour;
    }
}
