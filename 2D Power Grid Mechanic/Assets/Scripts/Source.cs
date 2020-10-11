using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : PowerObject
{

    public PowerOutput[] outputs;

    void Start() {
		powered = true;	// power source is always powered
		foreach (PowerOutput output in outputs) {
			output.SetPowered(true);    // set each output to powered
		}
    }

    void Update() {
        
    }
}
