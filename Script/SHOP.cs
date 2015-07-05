using UnityEngine;
using System.Collections;

public class SHOP : MonoBehaviour {
	public float nowMoney = 0;
	
	public GameObject target;
	public GameObject gm;
	public Collider2D SpeedUp;
	public Collider2D MassUp;
	public Collider2D HpUp;
	
	public float Mass;
	
	public Camera camera;
	
	void ActiveShop(int touches)
	{
		RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.GetTouch(touches).position), Vector3.zero);
		if (hit.collider == SpeedUp) {
			if (nowMoney >= (2*PlayerPrefs.GetInt("SpeedL")-1)*100 ) {
				PlayerPrefs.SetFloat("Speed", PlayerPrefs.GetFloat("Speed") + 0.25f);
				nowMoney -= (2*PlayerPrefs.GetInt("SpeedL")-1)*100;
				PlayerPrefs.SetInt("SpeedL", PlayerPrefs.GetInt("SpeedL") + 1);
			}
			else {
				//PlaySound;
				Debug.Log("No Money");
			}
		}
		
		if (hit.collider == MassUp) {
			if (nowMoney >= PlayerPrefs.GetInt("MassL") * 100) {
				PlayerPrefs.SetFloat("Mass", PlayerPrefs.GetFloat("Mass") + 0.0005f);
				nowMoney -= PlayerPrefs.GetInt("MassL") * 100;
				PlayerPrefs.SetInt("MassL", PlayerPrefs.GetInt("MassL") + 1);
				target.rigidbody2D.mass = PlayerPrefs.GetFloat("Mass");
			}
			else {
				//PlaySound;
				Debug.Log("No Money");
			}
		}
		if (hit.collider == HpUp) {
			if (nowMoney >= PlayerPrefs.GetInt("StageLevel") * 5) {
				PlayerPrefs.SetFloat("HP", PlayerPrefs.GetFloat("HP") + 10);
				nowMoney -= PlayerPrefs.GetInt("StageLevel") * 5;
			}
			else {
				//PlaySound;
				Debug.Log("No Money");
			}
		}
		PlayerPrefs.SetFloat("Money", nowMoney);
		gm.SendMessage("UpData");
	}
	
	// Use this for initialization
	void Start(){
		Mass = target.rigidbody2D.mass;
		PlayerPrefs.SetFloat("Mass", Mass);
	}
	
	// Update is called once per frame
	void Update() {
		
		nowMoney = PlayerPrefs.GetFloat("Money");
			for (int i = 0; i < Input.touchCount; i++) {
			Touch tuch = Input.GetTouch(i);
			if(tuch.phase.Equals(TouchPhase.Began))
			ActiveShop(i);
		}
	}
}
