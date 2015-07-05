using UnityEngine;
using System.Collections;

public class GetItem : MonoBehaviour {

	public GameObject Bread;
	public GameObject Coin;
	public GameObject gm;
	public void HPUP()
	{
		float nowHP = PlayerPrefs.GetFloat("HP");
		PlayerPrefs.SetFloat ("HP", nowHP+10);
	}

	public void MoneyUP()
	{
		float nowMoney = PlayerPrefs.GetFloat ("Money");
		PlayerPrefs.SetFloat ("Money", nowMoney+25* PlayerPrefs.GetInt("StageLevel"));
	}

	public void GetObject(GameObject other)
	{
		if(other.gameObject.tag == "ITEM")
		{
			if( other.gameObject.name == "Bread")
			{Debug.Log ("HPUP");
				HPUP ();}			
				else if(other.gameObject.name == "Coin") 
			{Debug.Log ("MONEYUP");
				MoneyUP();}
		}
		Debug.Log ("ReadyToCallGM");
		gm.GetComponent<GM>().SendMessage("UpData");
		Debug.Log ("Updata");
		this.gameObject.SetActive (false);
	}
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
	{
		GetObject (this.gameObject);
		Debug.Log ("TriggerOK");
	}
}
