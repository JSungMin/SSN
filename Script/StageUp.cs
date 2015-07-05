using UnityEngine;
using System.Collections;

public class StageUp : MonoBehaviour {

	public int stair = 1;

	public GameObject Stage;

	public GameObject LStair, RStair;

	public GameObject SystemMessage;
	public TweenAlpha FadeOut;

	public GameObject EnemyPool;
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Main" && this.tag == "Up(Idle)") 
		{
			PlayerPrefs.SetInt("SpawnCheck",1);
			if((PlayerPrefs.GetInt("StageLevel")+1)%2==0){		
				PlayerPrefs.SetInt("Spawn",2);
				PlayerPrefs.SetInt("StageLevel",PlayerPrefs.GetInt("StageLevel")+1);
				Stage.GetComponent<UILabel> ().text = "Stage : "+PlayerPrefs.GetInt("StageLevel");
				other.gameObject.GetComponent<Transform> ().localPosition = new Vector3 (260,70,other.gameObject.GetComponent<Transform> ().position.z);
				LStair.tag = "Up(Idle)";
				RStair.tag = "Up(Close)";
				Debug.Log("위로 이동");
			}
			else if((PlayerPrefs.GetInt("StageLevel")+1)%2!=0)
			{
				PlayerPrefs.SetInt("Spawn",1);
				PlayerPrefs.SetInt("StageLevel",PlayerPrefs.GetInt("StageLevel")+1);
				Stage.GetComponent<UILabel> ().text = "Stage : "+PlayerPrefs.GetInt("StageLevel");
				other.gameObject.GetComponent<Transform> ().localPosition = new Vector3 (-260,70,other.gameObject.GetComponent<Transform> ().position.z);
				LStair.tag = "Up(Close)";
				RStair.tag = "Up(Idle)";
				Debug.Log("위로 이동");
			}
		} 
		else if (other.gameObject.tag == "Main" &&this.tag == "Up(Close)") {
			SystemMessage.GetComponent<UILabel> ().text = "계단이 잠겨있습니다.(반대 계단으로 이동)";
			FadeOut = TweenAlpha.Begin(SystemMessage,2f,1f);
			FadeOut.enabled = true;
			FadeOut.from = 1f;
			FadeOut.to = 0f;
			FadeOut.Reset();
				}
		}
}