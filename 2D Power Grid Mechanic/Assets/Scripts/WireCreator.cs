using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCreator : MonoBehaviour {
    public GameObject wirePrefab, ghostWirePrefab; // 1m x 1m x 2m default unity cylinder
    public float width = 0.05f;

    GameObject ghostWire;
    Vector3 start, end, pos, oldPos;
	PowerOutput output;
	PowerInput input;
    bool creatingWire = false;
	bool snapped = false;

    void Start() {
	}

    void CreateWire() {
		this.start = output.transform.position;
		this.end = input.transform.position;
        Vector3 offset = end - start;
        Vector3 scale = new Vector3(width, offset.magnitude / 2.0f, this.width);
        Vector3 position = start + (offset / 2.0f);
        position.z += 0.1f;
        GameObject wire = Instantiate(wirePrefab, position, Quaternion.identity);
        wire.transform.up = offset;
        wire.transform.localScale = scale;
		Wire wireScript = wire.GetComponent<Wire>();    // grab the script component of the created wire
		wireScript.SetSource(output);	// set the output source for the wire
		wireScript.SetDest(input);      // set the input source for the wire
		output.AddWire(wireScript);		// add the wire to the list of wires for the output
		input.AddWire(wireScript);		// add the wire to the list of wires for the input
    }

	public void CreateGhost() {
		Destroy(ghostWire);	// destroy the old ghost
		this.start = output.transform.position;
		if (!snapped) {
			this.end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		end.z = 0.0f;
		Vector3 offset = end - start;
		Vector3 scale = new Vector3(width, offset.magnitude / 2.0f, this.width);
		Vector3 position = start + (offset / 2.0f);
		position.z += 0.1f;
		ghostWire = Instantiate(ghostWirePrefab, position, Quaternion.identity);
		ghostWire.name = "Wire Ghost";
		ghostWire.transform.up = offset;
		ghostWire.transform.localScale = scale;
	}


    void Update() {
		if (creatingWire) {
			CreateGhost();
		}
        if (!creatingWire && GameObject.Find("Wire Ghost") != null) {
            Destroy(ghostWire);
        }
    }

	public void setCreating(bool b) {
        this.creatingWire = b;
    }

    public bool isCreating() {
        return this.creatingWire;
    }

    public void SetDest(PowerInput input) {
        print("Ending wire creation");
		this.input = input;
    }

	public void StartCreation(PowerOutput output) {
		this.output = output;
		this.creatingWire = true;
		this.start = output.transform.position;
	}

    public void FinishCreation() {
		if (snapped) {  // check if the wire is currently snapped to an input
			CreateWire();
		}
		this.snapped = false;
        this.creatingWire = false;
    }

	public void SnapToInput(PowerInput input) {
		this.snapped = true;
		this.input = input;
		this.end = input.transform.position;
	}

	public void Unsnap() {
		this.snapped = false;
	}

    public void abortCreation() {
        this.creatingWire = false;
    }

}