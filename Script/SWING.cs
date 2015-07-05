using UnityEngine;
using System.Collections;

public class SWING : MonoBehaviour {

	public float HP; 
	Vector3 nowPosition;
	public GameObject gm;
	void Start()
	{
		HP = PlayerPrefs.GetInt("HP");
		nowPosition = this.transform.localPosition;
	}
	void Damaged()
	{
		if(HP>0)
		{
			PlayerPrefs.SetFloat("HP",(float)(PlayerPrefs.GetFloat("HP")-PlayerPrefs.GetFloat("EDamage")*0.5));
			gm.gameObject.GetComponent<GM>().SendMessage("UpData");
		}
		else
		{
			// Todo : Call GameOver
		}
	}
	// Use this for initialization
		void OnTriggerEnter2D(Collider2D other) {
		nowPosition = this.transform.localPosition;
		Debug.Log ("작동은 되냐?");

		if (other.gameObject.tag == "SKYR"&&this.gameObject.tag == "Enemy") {
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2(1,-1),ForceMode2D.Impulse);
			PlayerPrefs.SetFloat("Money",gm.GetComponent<GM>().money+50);
			gm.gameObject.GetComponent<GM>().SendMessage("UpData");
		} 
		if (other.gameObject.tag == "SKYL"&&this.gameObject.tag == "Enemy") {
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,-1),ForceMode2D.Impulse);
			PlayerPrefs.SetFloat("Money",gm.GetComponent<GM>().money+50);
			gm.gameObject.GetComponent<GM>().SendMessage("UpData");
		} 
		if (other.gameObject.tag == "SKYB" && this.gameObject.tag == "Enemy") {
			this.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, -1), ForceMode2D.Impulse);
			PlayerPrefs.SetFloat("Money",gm.GetComponent<GM>().money+50);
			gm.gameObject.GetComponent<GM>().SendMessage("UpData");
		} 
		else if (other.gameObject.tag == "SKYR" && this.gameObject.tag == "Main") {
			this.transform.localPosition  = (new Vector3 (nowPosition.x-50, nowPosition.y, 0));
			Damaged();
		} 
		else if (other.gameObject.tag == "SKYL" && this.gameObject.tag == "Main") {
			this.transform.localPosition =  (new Vector3 (nowPosition.x+50, nowPosition.y, 0));
			Damaged();
		}
		else if(other.gameObject.tag == "SKYB"&&this.gameObject.tag == "Main")
		{
			this.transform.localPosition = (new Vector3 (nowPosition.x,nowPosition.y+50,0));
			Damaged();
		}
	}
}
