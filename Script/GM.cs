using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {

	public int StageLevel = 1;

	public float HP = 100;
	public float Speed = 5.0f;
	public float SpeedE = 3.0f;
	public float Mass;

	public int HPLevel = 1;
	public int SpeedLevel = 1;
	public int MassLevel = 1;

	public float FDamage = 5;
	public float EDamage = 5;
	public int Bread;
	public float money=0;

	public GameObject SLabel;
	public GameObject MLabel;
	public GameObject MoneyLabel;

	public GameObject HPPrice;
	public GameObject SpeedPrice;
	public GameObject MassPrice;
	// Use this for initialization
	void Start () {
				PlayerPrefs.SetInt ("StageLevel", 1);
				PlayerPrefs.SetFloat ("HP", 100);
				if (PlayerPrefs.GetFloat ("Speed") <= 5)
						PlayerPrefs.SetFloat ("Speed", 5);
				else {
						PlayerPrefs.SetFloat ("Speed", PlayerPrefs.GetFloat ("Speed"));
				}
				PlayerPrefs.SetInt ("Spawn", 1);
				if (PlayerPrefs.GetFloat ("FDamage") <= 5)
						PlayerPrefs.SetFloat ("FDamage", 5);
				else {
						PlayerPrefs.SetFloat ("FDamage", PlayerPrefs.GetFloat ("FDamage"));
				}
				if (PlayerPrefs.GetFloat ("EDamage") <= 5)
						PlayerPrefs.SetFloat ("EDamage", 5);
				else {
						PlayerPrefs.SetFloat ("EDamage", PlayerPrefs.GetFloat ("EDamage"));
				}
				PlayerPrefs.SetFloat ("SpeedE", 3);
				PlayerPrefs.SetInt ("HPL", HPLevel);
				PlayerPrefs.SetInt ("SpeedL", SpeedLevel);
				PlayerPrefs.SetInt ("MassL", MassLevel);
				money = PlayerPrefs.GetFloat ("Money");

		}

	// Update is called once per frame
	public void UpData () {
		MassLevel = PlayerPrefs.GetInt("MassL");
		StageLevel = PlayerPrefs.GetInt ("StageLevel");
		SpeedLevel = PlayerPrefs.GetInt ("SpeedL");

		HP = PlayerPrefs.GetFloat ("HP");
		money = PlayerPrefs.GetFloat("Money");
		Speed = PlayerPrefs.GetFloat ("Speed");
		SpeedE = PlayerPrefs.GetFloat ("SpeedE");
		FDamage = PlayerPrefs.GetFloat ("FDamage");
		EDamage = PlayerPrefs.GetFloat ("EDamage");
		Mass = PlayerPrefs.GetFloat ("Mass");

		MLabel.GetComponent<UILabel> ().text = ""+MassLevel;
		SLabel.GetComponent<UILabel> ().text = ""+SpeedLevel;
		MoneyLabel.GetComponent<UILabel> ().text = ""+money;

		HPPrice.GetComponent<UILabel> ().text = (PlayerPrefs.GetInt("StageLevel")) * 5+" $";
		SpeedPrice.GetComponent<UILabel>().text = (2*PlayerPrefs.GetInt("SpeedL"))*100+" $";
		MassPrice.GetComponent<UILabel> ().text = PlayerPrefs.GetInt ("MassL") * 100 + " $";

	}
}
