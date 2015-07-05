using UnityEngine;
using System.Collections;

public class Seek2 : MonoBehaviour{

	public Vector3 FirstPosition;
	public Transform enemy;
	public Transform target;
	public float EnemySpeed = 0;
	public Vector2 dir = Vector3.zero;

	public GameObject EnemyHObj;
	public GameObject EnemyBObj;
	
	public GameObject EnemyLA;
	public GameObject EnemyRA;
	public Animator Anime;

	public float HP;

	void Start()
	{
		HP = 100;
		FirstPosition = transform.localPosition;
	}
	public void Reset()
	{
		transform.localPosition = FirstPosition;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		dir= new Vector2(target.transform.position.x -enemy.transform.position.x,0).normalized;
		if (other.gameObject.tag=="obstacle"&&other.gameObject.transform.localPosition.y<=200)
		{
			Debug.Log ("CollisionOK");
			enemy.rigidbody2D.AddForce((-Vector2.up+dir)*EnemySpeed,ForceMode2D.Force);		
		}
		else if(other.gameObject.tag=="obstacle"&&other.gameObject.transform.localPosition.y>200){
			Debug.Log ("CollisionOK");
			enemy.rigidbody2D.AddForce((Vector2.up+dir)*EnemySpeed,ForceMode2D.Force);
		}
		else if(other.gameObject.tag=="Enemy"){
			enemy.rigidbody2D.AddForce((enemy.transform.position-target.transform.position).normalized*EnemySpeed*2,ForceMode2D.Force);
		}
	}

	public void Seeker(){
		if(EnemySpeed<PlayerPrefs.GetFloat("SpeedE")){
			EnemySpeed+=Time.fixedDeltaTime;
		}
		dir = new Vector2(target.transform.position.x -enemy.transform.position.x,target.transform.position.y -enemy.transform.position.y).normalized;
		if (enemy.rigidbody2D.angularVelocity <= 2.0f)
						enemy.rigidbody2D.AddForce (dir * EnemySpeed * Time.fixedDeltaTime, ForceMode2D.Force);
				else
						enemy.rigidbody2D.angularVelocity = 2.0f;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (dir.x > 0) {
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
		} else if (dir.x < 0) {
			Anime.SetBool ("LGoChk",true);
			Anime.SetBool ("RGoChk", false);
			EnemyHObj.GetComponent<UISprite> ().spriteName = "EnemyLeft-H";
			EnemyLA.GetComponent<UISprite> ().spriteName = "EnemyLeft-RHand";
			EnemyRA.GetComponent<UISprite> ().spriteName = "EnemyLeft-LHand";
			EnemyBObj.GetComponent<UISprite> ().spriteName = "EnemyLeft-M";
			EnemyRA.GetComponent<UISprite> ().depth = 11;
			EnemyLA.GetComponent<UISprite> ().depth = 8;
			if(EnemyLA.transform.localScale.x>0)
			{
				EnemyLA.transform.localScale = new Vector3(-EnemyLA.GetComponent<UISprite> ().transform.localScale.x,EnemyLA.GetComponent<UISprite> ().transform.localScale.y,EnemyLA.GetComponent<UISprite> ().transform.localScale.z);
				EnemyRA.transform.localScale = new Vector3(-EnemyRA.GetComponent<UISprite> ().transform.localScale.x,EnemyRA.GetComponent<UISprite> ().transform.localScale.y,EnemyRA.GetComponent<UISprite> ().transform.localScale.z);
			}
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
		Seeker ();
	}
}
