using UnityEngine;
using System.Collections;

public class BGLayer : MonoBehaviour {

	void Start () {
		GetComponent<Renderer>().sortingLayerName = "BG";
		GetComponent<Renderer>().sortingOrder = 0;
	}
}
