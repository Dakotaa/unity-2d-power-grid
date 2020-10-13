using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour {

	private PowerOutput source;	// source power output - start point
	private PowerInput dest; // destination power intput - end point
	private bool powered;
	private WireCreator wireCreator;
	private Editor editor;

	public void SetSource(PowerOutput source) {
		this.source = source;
	}

	public void SetDest(PowerInput dest){
		this.dest = dest;	
	}

	public void SetPowered(bool powered) {
		this.powered = powered;
		dest.SetPowered(powered);
		dest.Signal();
	}

	public bool IsPowered() {
		return this.powered;
	}

	public void Delete() {
		if (editor.GetMode() == 2) {
			source.RemoveWire(this);
			dest.RemoveWire(this);
			Destroy(this.gameObject);
		}
	}

	void Start() {
		wireCreator = FindObjectOfType(typeof(WireCreator)) as WireCreator;
		editor = FindObjectOfType(typeof(Editor)) as Editor;
	}

    void Update() { }
}
