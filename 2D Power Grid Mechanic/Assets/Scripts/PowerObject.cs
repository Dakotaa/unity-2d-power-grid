using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PowerObject : MonoBehaviour {
	public bool powered, connected;

	public abstract void Signal();

	public void SetPowered(bool powered) {
		this.powered = powered;
		Signal();
	}

	public bool GetPowered() {
		return this.powered;
	}

	public void SetConnected(bool connected) {
		this.connected = connected;
		Signal();
	}

	public bool GetConnected() {
		return this.connected;
	}

	void Start() {}

    void Update() {}
}
