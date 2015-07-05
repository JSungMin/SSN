using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {
	
	public int MeteorCount;
	public int EraserCount;

	public BoxCollider2D Mete;
	public BoxCollider2D Era;

	public GameObject Eraser;
	public GameObject GM;
	public Transform main;

	public void Start()
	{
		MeteorCount = 0;
		EraserCount = 0;
	}

	public void RayCheck(int touches)
	{
		RaycastHit2D hit = Physics2D.Raycast(this.camera.ScreenToWorldPoint(Input.GetTouch(touches).position), Vector2.zero);
		if(hit.collider == Era)
		{
			if(Eraser.activeSelf==false)
			Eraser.SetActive(true);
		}
	}

	public void Update()
	{
		for (int i = 0; i<Input.touchCount; i++) {
			Touch touch = Input.GetTouch(i);
			if(touch.phase.Equals(TouchPhase.Began))
			{
				RayCheck (i);
			}
			if(touch.phase.Equals(TouchPhase.Ended))
			{
				
			}
		}
		//PC Version
		if(Input.GetKeyDown(KeyCode.Keypad1))
		{
			if(Eraser.activeSelf==false)
			{
				if(PlayerPrefs.GetFloat("Money")>=20)
				{
					PlayerPrefs.SetFloat("Money",GM.GetComponent<GM>().money-20);
					GM.GetComponent<GM>().SendMessage("UpData");
					Eraser.GetComponent<EraserB>().fVec = main.localPosition;
					Eraser.GetComponent<EraserB>().fDir = GetComponent<JM>().dir;
					Eraser.transform.localPosition = new Vector3(main.transform.localPosition.x+Eraser.GetComponent<EraserB>().fDir.x*70,main.transform.localPosition.y+Eraser.GetComponent<EraserB>().fDir.y*200);
					Eraser.SetActive(true);
				}
				else{
					Debug.Log ("You Don't have money");
				}
			}
		}
	}
}
