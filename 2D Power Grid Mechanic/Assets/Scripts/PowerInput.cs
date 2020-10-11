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


    void Update() {
		if (connected) { // when there are connections, update them
			foreach (Wire wire in wires) {
				if (wire.IsPowered()) {
					powered = true;
					UpdatePowerObject();
				}
			}
		}
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
		UpdatePowerObject();
	}

	public void RemoveWire(Wire wire) {
		wires.Remove(wire);
		if (wires.Count == 0) {
			powered = false;
			connected = false;
			UpdatePowerObject();
		}
	}

	public void UpdatePowerObject() {
		if (this.powered) { // if this input is powered, but the game object is not, power it
			if (!powerObject.GetPowered()) {
				powerObject.SetPowered(true);
			}
		} else {
			if (powerObject.GetPowered()) {
				powerObject.SetPowered(false);
			}
		}
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
