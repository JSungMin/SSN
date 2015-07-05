using UnityEngine;
using System.Collections;

public class AIEnemy : MonoBehaviour {
	public Animator Anime; 
	public GameObject EnemyHObj;
	public GameObject EnemyBObj;
	
	public GameObject EnemyLA;
	public GameObject EnemyRA;

	private int dropItem;

	//쫓을 대상
	public Transform target;
	
	public Rigidbody2D rb;
	
	/*Type2*/
	public Vector3 dir2;
	public float distance2;
	public Vector3 fVec;
	public bool re = false;
	/*EnemyAnimation*/
	public int Frame = 0;
	public int turn = 1;

	public float HP = 100;

	public void Start()
	{
		dropItem = Random.Range (0,3);
		rb = GetComponent<Rigidbody2D>();
		fVec = transform.localPosition;
	}

	public int GetItemIndex()
	{
		return dropItem;
	}

	public void Reset()
	{
		HP = 100;
		transform.localPosition = fVec;
	}

	//AI_T2
	void Type2Moving(Vector3 dir, float distance/*Block amount*/, Vector3 firstVec){
		Vector3 nowVec = transform.localPosition;
		if (re == false) {
			if (dir.x != 0) {
				rb.velocity = dir * 7 * PlayerPrefs.GetFloat("SpeedE") * Time.fixedDeltaTime;
				if (Vector3.Distance(new Vector3(nowVec.x, 0, 0), new Vector3(firstVec.x + distance*dir.x, 0, 0)) <= 50)
				re = true;
			}
			else if (dir.y != 0) {
				rb.velocity = dir * 7 * PlayerPrefs.GetFloat("SpeedE") * Time.fixedDeltaTime;
				if (Vector3.Distance(new Vector3(0, nowVec.y, 0), new Vector3(0, firstVec.y + distance*dir.y, 0)) <= 50)
					re = true;
			}
		}
		else {
			if (dir.x != 0) {
				rb.velocity = -dir * 7 * PlayerPrefs.GetFloat("SpeedE") * Time.fixedDeltaTime;
				if (Vector3.Distance(new Vector3(nowVec.x, 0, 0), new Vector3(firstVec.x, 0, 0)) <= 30)
					re = false;
			}
			else if (dir.y != 0) {
				rb.velocity = -dir * 7 * PlayerPrefs.GetFloat("SpeedE") * Time.fixedDeltaTime;
				if (Vector3.Distance(new Vector3(0, nowVec.y, 0), new Vector3(0, firstVec.y, 0)) <= 30)
					re = false;
			}
			
		}
		
	}

	void FixedUpdate(){
		//Type2
		if (this.gameObject.name == "Enemy_T2" || this.gameObject.name == "Enemy_T2_2" || this.gameObject.name == "Enemy_T2_3") {
			Vector3 di = (target.transform.localPosition-this.transform.localPosition).normalized;
			if (di.x > 0) {
				Anime.SetBool ("LGoChk", false);
				Anime.SetBool ("RGoChk", true);
				EnemyHObj.GetComponent<UISprite>().spriteName = "EnemyRight-H";
				EnemyBObj.GetComponent<UISprite>().spriteName = "EnemyLeft-M";
				EnemyLA.GetComponent<UISprite> ().spriteName = "EnemyLeft-RHand";
				EnemyRA.GetComponent<UISprite> ().spriteName = "EnemyLeft-LHand";
				EnemyLA.GetComponent<UISprite> ().depth = 11;
				EnemyRA.GetComponent<UISprite> ().depth = 8;
				if(EnemyLA.transform.localScale.x>0)
				{
				EnemyLA.transform.localScale = new Vector3(-EnemyLA.GetComponent<UISprite> ().transform.localScale.x,EnemyLA.GetComponent<UISprite> ().transform.localScale.y,EnemyLA.GetComponent<UISprite> ().transform.localScale.z);
				EnemyRA.transform.localScale = new Vector3(-EnemyRA.GetComponent<UISprite> ().transform.localScale.x,EnemyRA.GetComponent<UISprite> ().transform.localScale.y,EnemyRA.GetComponent<UISprite> ().transform.localScale.z);
				}
			} else if (di.x < 0) {
				Anime.SetBool ("LGoChk",true);
				Anime.SetBool ("RGoChk", false);
				EnemyHObj.GetComponent<UISprite> ().spriteName = "EnemyLeft-H";
				EnemyLA.GetComponent<UISprite> ().spriteName = "EnemyLeft-RHand";
				EnemyRA.GetComponent<UISprite> ().spriteName = "EnemyLeft-LHand";
				EnemyRA.GetComponent<UISprite> ().depth = 11;
				EnemyLA.GetComponent<UISprite> ().depth = 8;
				if(EnemyLA.transform.localScale.x>0)
				{
				EnemyLA.transform.localScale = new Vector3(-EnemyLA.GetComponent<UISprite> ().transform.localScale.x,EnemyLA.GetComponent<UISprite> ().transform.localScale.y,EnemyLA.GetComponent<UISprite> ().transform.localScale.z);
				EnemyRA.transform.localScale = new Vector3(-EnemyRA.GetComponent<UISprite> ().transform.localScale.x,EnemyRA.GetComponent<UISprite> ().transform.localScale.y,EnemyRA.GetComponent<UISprite> ().transform.localScale.z);
				}
				EnemyBObj.GetComponent<UISprite> ().spriteName = "EnemyLeft-M";

			} else {
				Anime.SetBool ("LGoChk", false);
				Anime.SetBool ("RGoChk", false);
				EnemyHObj.GetComponent<UISprite> ().spriteName = "EnemyFoward-Head";
				EnemyBObj.GetComponent<UISprite> ().spriteName = "EnemyFoward-M";
				EnemyLA.GetComponent<UISprite> ().spriteName = "EnemyForwad-LHand";
				EnemyRA.GetComponent<UISprite> ().spriteName = "EnemyForwad-RHand";
				EnemyLA.GetComponent<UISprite> ().depth = 8;
				EnemyRA.GetComponent<UISprite> ().depth = 8;
				if(EnemyLA.transform.localScale.x<0)
				{
				EnemyLA.transform.localScale = new Vector3(-EnemyLA.GetComponent<UISprite> ().transform.localScale.x,EnemyLA.GetComponent<UISprite> ().transform.localScale.y,EnemyLA.GetComponent<UISprite> ().transform.localScale.z);
				EnemyRA.transform.localScale = new Vector3(-EnemyRA.GetComponent<UISprite> ().transform.localScale.x,EnemyRA.GetComponent<UISprite> ().transform.localScale.y,EnemyRA.GetComponent<UISprite> ().transform.localScale.z);
				}
			}
			Type2Moving(dir2, distance2, fVec);
		}
		
		//Type3
		if (this.gameObject.name == "Enemy_T3") {
		}
		
		
	}
	
}
