using UnityEngine;
using System.Collections;

public class MainLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().sortingLayerName = "Main";
		GetComponent<Renderer>().sortingOrder = 4;
	}
}
