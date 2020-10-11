using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleNode : PowerObject {

    public PowerInput[] inputs;
    public GameObject box;

    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (powered) {
            setColour(Color.green);
        } else {
            setColour(Color.red);
        }
    }

    void setColour(Color colour) {
        box.GetComponent<Renderer>().material.color = colour;
    }
}
