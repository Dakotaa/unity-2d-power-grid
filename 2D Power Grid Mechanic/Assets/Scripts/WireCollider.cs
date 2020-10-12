using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCollider : MonoBehaviour {
	public Wire wire;

	private void OnMouseDown() {
		wire.Delete();
	}

}
