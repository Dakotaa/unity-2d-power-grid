using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerInput : MonoBehaviour {
    public PowerObject powerObject;
    public WireCreator wireCreator;
	private List<Wire> wires;   // list of wires connected to this input 
	private bool connected; // whether this input is connected to wires
	private bool powered, over;

    void Start() {
        wireCreator = FindObjectOfType(typeof(WireCreator)) as WireCreator; // get the wire creator
		wires = new List<Wire>();
		connected = false;
	}


    void Update() {}

	public void Signal() {
		if (connected) { // when there are connections, update them
			foreach (Wire wire in wires) {	// check each connected wire
				if (wire.IsPowered()) {
					print("POWERING INPUT");
					this.powered = true;
					powerObject.Signal();
					return;	// not necessary to search for other power sources
				}
			}
		}
		this.powered = false; // not connected, or a powered wire was not found
		powerObject.Signal();
	}

	public void SetPowered(bool powered) {
		this.powered = powered;
		this.powerObject.SetPowered(powered);
	}

	public bool IsPowered() {
		return this.powered;
	}

	public void AddWire(Wire wire) {
		wires.Add(wire);
		connected = true;
		Signal();
	}

	public void RemoveWire(Wire wire) {
		wires.Remove(wire);
		if (wires.Count == 0) {
			print("NO WIRES LEFT");
			powered = false;
			connected = false;
		}
		Signal();
	}

	private void OnMouseEnter() {
		if (wireCreator.isCreating()) {
			wireCreator.SnapToInput(this);
		}
	}

	private void OnMouseExit() {
		if (wireCreator.isCreating()) {
			wireCreator.Unsnap();
		}
	}
}
