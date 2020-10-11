using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PowerObject : MonoBehaviour {
	public bool powered;

	public void SetPowered(bool powered) {
		this.powered = powered;
	}

	public bool GetPowered() {
		return this.powered;
	}

	void Start() {}

    void Update() {}
}
