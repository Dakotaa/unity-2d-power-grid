using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public Connector connector;
    int power;
    int status;
 
    // Start is called before the first frame update
    void Start() {
        power = 0;
        status = 0;
    }

    // Update is called once per frame
    void Update() {
        if (status == 1) {
            setColour(Color.green);
        } else
        {
            setColour(Color.red);
        }
    }

    private void OnMouseDown() {
        if (status == 0) {
            status = 1;
        } else {
            status = 0;
        }
    }

    void setColour(Color colour)
    {
        gameObject.GetComponent<Renderer>().material.color = colour;
    }

    public void SetStatus(int status)
    {
        this.status = status;
    }
}
