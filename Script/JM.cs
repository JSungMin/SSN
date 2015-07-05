using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JM : MonoBehaviour {
	public ParticleSystem Eff;
	public ParticleSystem Eff2;
	public ParticleSystem Eff3;
	
	public GameObject EffPool;
	public GameObject temptEff;
	
	
	public GameObject _buttonT;
	public GameObject _buttonB;
	public GameObject _buttonR;
	public GameObject _buttonL;
	
	public GameObject _buttonTR;
	public GameObject _buttonTL;
	public GameObject _buttonBR;
	public GameObject _buttonBL;
	
	public GameObject AttackPoint;
	
	private BoxCollider2D _colliderL;
	private BoxCollider2D _colliderR;
	private BoxCollider2D _colliderT;
	private BoxCollider2D _colliderB;
	
	public BoxCollider2D _colliderTR;
	public BoxCollider2D _colliderTL;
	public BoxCollider2D _colliderBR;
	public BoxCollider2D _colliderBL;
	
	private float mx, my;
	
	public GameObject _target;
	public float _speed = PlayerPrefs.GetFloat("Speed");
	private Vector3 _inipos;
	
	public int frame = 0;
	
	public  BoxCollider2D fake;
	public Vector3 dir = Vector3.zero;
	public Vector3 dirsave = Vector3.zero;
	
	public GameObject EnemyPool;
	
	public bool immotal = false;
	
	void Start(){
		
		dirsave = dir;
		_colliderT = _buttonT.GetComponent<BoxCollider2D>();
		_colliderB = _buttonB.GetComponent<BoxCollider2D>();
		_colliderL = _buttonL.GetComponent<BoxCollider2D>();
		_colliderR = _buttonR.GetComponent<BoxCollider2D>();
		
		_colliderTR = _buttonTR.GetComponent<BoxCollider2D>();
		_colliderTL = _buttonTL.GetComponent<BoxCollider2D>();
		_colliderBR = _buttonBR.GetComponent<BoxCollider2D>();
		_colliderBL = _buttonBL.GetComponent<BoxCollider2D>();
		_inipos = _target.transform.localPosition;
		
	}
	
	public Animator Anime;
	//anime sprite change
	public GameObject mainHead;
	public GameObject mainBody;
	
	public GameObject HPamount;
	
	void ChangeSprite(string spriteName, string spriteName2)
	{
		mainHead.GetComponent<UISprite>().spriteName = spriteName;
		mainBody.GetComponent<UISprite>().spriteName = spriteName2;
	}
	bool changeChk = false;
	void Update(){
		HPamount.GetComponent<UISprite>().fillAmount = 1 - PlayerPrefs.GetFloat("HP") / 100;
		for (int i = 0; i < Input.touchCount; i++) {
			Touch touch = Input.GetTouch(i);
			if (dir.x != 0 && changeChk == false) {
				ChangeSprite("MainLeft-H", "MainLeft-M");
				changeChk = true;
			}
			if (touch.phase.Equals(TouchPhase.Began))
			{
				
				RayCheck(i);
				DeleteEff(EffPool);
			}
			if (touch.phase.Equals(TouchPhase.Moved))
			{
				RayCheck(i);
			}
			if (touch.phase.Equals(TouchPhase.Stationary))
			{
				RayCheck(i);
			}
			if (touch.phase.Equals(TouchPhase.Ended))
			{
				dir = Vector3.zero;
				Anime.SetBool("goLeftChk", false);
				Anime.SetBool("goRightChk", false);
				ChangeSprite("MainForward-Head", "MainForward-M");
				changeChk = false;
				frame = 0;
			}
			
		}
		
		//PC Version JM
		float dirX = Input.GetAxis("Horizontal");
		float dirY = Input.GetAxis("Vertical");
		_target.rigidbody2D.velocity = new Vector3(dirX*2.5f, dirY*2.5f, 0);
		dir.x = dirX;
	}
	public void DeleteEff(GameObject EPool)
	{
		if (EPool.transform.childCount != 0)
		{
			for (int k = 0; k < EPool.transform.childCount; k++)
			{
				Destroy(EPool.transform.GetChild(k).gameObject);
				Debug.Log("Crack was Deleted");
			}
		}
		
	}
	public void CreateEff(GameObject original)
	{
		var crack = (GameObject)Instantiate(original, Vector3.zero, Quaternion.identity);
		crack.GetComponent<Renderer>().sortingLayerName = "Effect";
		crack.GetComponent<Renderer>().sortingOrder = 3;
		crack.transform.parent = EffPool.transform;
		crack.transform.localScale = new Vector3(1f, 1f, 1f);
		crack.transform.localPosition = new Vector3(-dirsave.x * 1 * (5 - frame), -dirsave.y * 1 * (5 - frame), 0);
		temptEff = crack;
		_target.transform.localPosition = skillPosition;
		crack.particleSystem.Play();
	}
	public Vector3 skillPosition = Vector3.zero;
	void RayCheck(int touches){
		RaycastHit2D hit = Physics2D.Raycast(this.camera.ScreenToWorldPoint(Input.GetTouch(touches).position), Vector2.zero);
		
		if (dir.x > 0)
			Anime.SetBool("goRightChk", true);
		else if (dir.x < 0)
			Anime.SetBool("goLeftChk", true);
		//Top
		if (hit.collider == _colliderT) {
			dir = Vector3.up;
			_target.rigidbody2D.AddForce(dir*PlayerPrefs.GetFloat("Speed") / 4 * Time.fixedDeltaTime);
		}
		//Bottom
		else if (hit.collider == _colliderB) {
			dir = Vector3.down;
			_target.rigidbody2D.AddForce(dir*PlayerPrefs.GetFloat("Speed") / 4 * Time.fixedDeltaTime);
		}
		//Left
		else if (hit.collider == _colliderL) {
			dir = Vector3.left;
			_target.rigidbody2D.AddForce(dir*PlayerPrefs.GetFloat("Speed") / 4 * Time.fixedDeltaTime);
		}
		//Right
		else if (hit.collider == _colliderR) {
			dir = Vector3.right;
			_target.rigidbody2D.AddForce(dir*PlayerPrefs.GetFloat("Speed") / 4 * Time.fixedDeltaTime);
		}
		//Top Right
		else if (hit.collider == _colliderTR) {
			dir = Vector3.up + Vector3.right;
			_target.rigidbody2D.AddForce(dir*PlayerPrefs.GetFloat("Speed") / 4 * Time.fixedDeltaTime);
		}
		//Top Left
		else if (hit.collider == _colliderTL) {
			dir = Vector3.up + Vector3.left;
			_target.rigidbody2D.AddForce(dir*PlayerPrefs.GetFloat("Speed") / 4 * Time.fixedDeltaTime);
		}
		//Bottom Right
		else if (hit.collider == _colliderBR) {
			dir = Vector3.down + Vector3.right;
			_target.rigidbody2D.AddForce(dir*PlayerPrefs.GetFloat("Speed") / 4 * Time.fixedDeltaTime);
		}
		//Bottom Left
		else if (hit.collider == _colliderBL) {
			dir = Vector3.down + Vector3.left;
			_target.rigidbody2D.AddForce(dir*PlayerPrefs.GetFloat("Speed") / 4 * Time.fixedDeltaTime);
		}
		
		dirsave = dir;
		//Skill1 Go!
		if (hit.collider == fake) {
			if (frame <= PlayerPrefs.GetInt("SpeedL") + 2)
			{
				immotal = true;
				Debug.Log("Hit Skill1");
				float nowx = _target.transform.localPosition.x;
				float nowy = _target.transform.localPosition.y;
				skillPosition = new Vector3((nowx + dirsave.x*PlayerPrefs.GetInt("SpeedL") * 20),
				                            (nowy + dirsave.y*PlayerPrefs.GetInt("SpeedL") * 20),
				                            0);
				CreateEff(Eff2.gameObject);
				Eff3.particleSystem.Play();
				PlayerPrefs.SetFloat("HP", PlayerPrefs.GetFloat("HP") - (1 + (int)PlayerPrefs.GetInt("StageLevel") / 5));
				frame++;
			}
			else
				immotal = false;
		}
	}
}