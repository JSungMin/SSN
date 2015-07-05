using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().sortingLayerName = "Effect";
		GetComponent<Renderer>().sortingOrder = 3;
	}
}
