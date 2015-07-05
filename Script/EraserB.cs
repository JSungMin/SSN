using UnityEngine;
using System.Collections;

public class EraserB : MonoBehaviour {
	public GameObject gm;
	public GameObject Main;

	public int frame = 0 ;

	public Vector3 fVec;
	public Vector3 fDir;

	void FixedUpdate()
	{
		rigidbody2D.velocity = fDir * 30;
		rigidbody2D.angularVelocity = fDir.x * 120;
	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("Why?");
		if(other.gameObject.tag == "SKYR"||other.gameObject.tag == "SKYL"||other.gameObject.tag == "SKYB")
		{
			frame = 0;
			this.transform.localPosition = fVec;
			Debug.Log ("왜 안돼?");
			this.gameObject.SetActive(false);
		}
	}

	public void OnCollisionEnter2D (Collision2D other)
	{
		Debug.Log ("명중");
		
		if (other.gameObject.CompareTag ("Enemy")) {
			var Enemy = other.gameObject;
			if (Enemy.name == "Enemy_T2" || Enemy.name == "Enemy_T3") {
				Enemy.GetComponent<AIEnemy> ().HP -= 20;
				if(other.gameObject.GetComponent<AIEnemy>().HP<=0)
				{
					other.gameObject.GetComponent<AIEnemy>().Reset();
					other.gameObject.SetActive(false);
				}
			}
			if (Enemy.name == "Enemy_T1") {
				Enemy.GetComponent<Seek2> ().HP -= 20;
				if(other.gameObject.GetComponent<Seek2>().HP<=0)
				{
					other.gameObject.GetComponent<Seek2>().Reset();
					other.gameObject.SetActive(false);
				}
			}
			var dir = (other.transform.localPosition - this.transform.localPosition).normalized;
			other.rigidbody.AddForce(dir*0.00005f);
			frame = 0;
			this.gameObject.SetActive(false);
			this.transform.localPosition = fVec;
		} 
		else 
		{
			frame = 0;
			this.gameObject.SetActive(false);
			this.transform.localPosition = fVec;
		}
	}

}
