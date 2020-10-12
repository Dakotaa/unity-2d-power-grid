using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PowerObject : MonoBehaviour {
	public bool powered;

	public abstract void Signal();

	public void SetPowered(bool powered) {
		this.powered = powered;
		Signal();
	}

	public bool GetPowered() {
		return this.powered;
	}

	void Start() {}

    void Update() {}
}
