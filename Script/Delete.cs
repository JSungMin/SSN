using UnityEngine;
using System.Collections;

public class Delete : MonoBehaviour {
	GameObject gm;
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.SetActive(false);
			if(other.gameObject.name == "Enemy_T1")
			{
				other.gameObject.GetComponent<Seek2>().Reset();
			}
			else{
				other.gameObject.GetComponent<AIEnemy>().Reset();
			}
			PlayerPrefs.SetFloat("Money",PlayerPrefs.GetFloat("Money")+50.0f);
				}
	}
}
