using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stage : MonoBehaviour {
	
	public bool turn;
	public Transform ObjPool1;

	public GameObject Map;
	int indexMap;
	public Transform _target;
	void DeleteOB(int nowMap)
	{
		ObjPool1.GetChild(0).transform.GetChild(nowMap).gameObject.SetActive(false);
		Debug.Log (ObjPool1.GetChild (0).transform.GetChild (nowMap).gameObject);
		return;
	}
	
	// Stage 1
	
	void Start() {
		indexMap = Random.Range(0,8);
		PlayerPrefs.SetInt("SpawnCheck", 1);
		turn = true;
	}
	void Update(){
		if (PlayerPrefs.GetInt("SpawnCheck") == 1){
			DeleteOB(indexMap);
			indexMap= Random.Range(0,8);
			Debug.Log("Stage돌입");
			ObjPool1.GetChild(0).transform.GetChild(indexMap).gameObject.SetActive(true);
			PlayerPrefs.SetInt("Spawn", 1);
			PlayerPrefs.SetInt("SpawnCheck", 0);
		}
	}
	
}