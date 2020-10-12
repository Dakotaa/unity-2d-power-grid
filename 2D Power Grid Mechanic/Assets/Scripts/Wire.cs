using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour {

	private PowerOutput source;	// source power output - start point
	private PowerInput dest; // destination power intput - end point
	private bool powered;

	public void SetSource(PowerOutput source) {
		this.source = source;
	}

	public void SetDest(PowerInput dest){
		this.dest = dest;	
	}

	public void SetPowered(bool powered) {
		this.powered = powered;
		dest.SetPowered(powered);
	}

	public bool IsPowered() {
		return this.powered;
	}

	public void Delete() {
		source.RemoveWire(this);
		dest.RemoveWire(this);
		Destroy(this.gameObject);
	}

	void Start() {
        
    }

    void Update() {
        
    }
}
