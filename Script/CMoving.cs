using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CMoving : MonoBehaviour {

	public GameObject _target;
	private Vector3 _iniPos;
	public float _speed=0.3f;
	public float _delspeed=0.0f;
	void Start(){
		Physics2D.IgnoreLayerCollision (8, 10,true);
		}
	void OnTriggerEnter2D(Collider2D other) {
			_iniPos = _target.transform.position;
		Debug.Log ("작동은 되냐?");
		if (other.gameObject.tag == "obstacle") {
						Debug.Log ("옵스타클이다");
						if (_iniPos == Vector3.up) {
								Debug.Log ("으아아아아");
								_target.transform.Translate (Vector3.down * _delspeed * Time.deltaTime);
						}
						if (_iniPos == Vector3.down) {
								_target.transform.Translate (Vector3.up * _delspeed * Time.deltaTime);
						}
						if (_iniPos == Vector3.left) {
								_target.transform.Translate (Vector3.right * _delspeed * Time.deltaTime);
						}
						if (_iniPos == Vector3.right) {
								_target.transform.Translate (Vector3.left * _delspeed * Time.deltaTime);
						}

				} 
		else if (other.gameObject.tag == "ITEM" ){
			Debug.Log("성공?");
				}
	}
	void Update(){
		_delspeed += _speed;
	}
}
