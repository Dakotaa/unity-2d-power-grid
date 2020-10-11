using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOutput : MonoBehaviour {
    public PowerObject powerObject; // associated powerable object
    public WireCreator wireCreator; // wirecreator - assigned on Start()
    private List<Wire> wires;   // list of wires connected to this output 
    private bool connected; // whether this output is connected to wires
	private bool powered; // whether this output has power

    void Start() {
        wireCreator = FindObjectOfType(typeof(WireCreator)) as WireCreator;
		wires = new List<Wire>();
        connected = false;
    }

	void Update() {
		if (connected) { // when there are connections, update them
			foreach (Wire wire in wires) {
				wire.SetPowered(powered);
			}
		}
    }

	public void SetPowered(bool powered) {
		this.powered = powered;
	}

	public bool IsPowered() {
		return this.powered;
	}

	public void AddWire(Wire wire) {
		wires.Add(wire);
		connected = true;
	}

	public void RemoveWire(Wire wire) {
		wires.Remove(wire);
		if (wires.Count == 0) {
			connected = false;
		}
	}

    private void OnMouseDown() {
		wireCreator.StartCreation(this);
    }

	private void OnMouseUp() {
		wireCreator.FinishCreation();
	}


	private void OnMouseDrag() {
	
	}

}
