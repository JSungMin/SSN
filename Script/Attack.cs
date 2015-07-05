
using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	
	public Camera camera;
	public ForceMode2D fMode;
	public int att = 0;
	
	public ParticleSystem Eff;
	public void PlayEff(GameObject Effect)
	{
		Effect.particleSystem.Play();
	}
	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log("AttackReady");
		//from Player to Enemy
		
		if (other.gameObject.tag == "Enemy") {
			Debug.Log("AttackP->E");
			att = 1;
			PlayerPrefs.SetInt("AttackCh", att);
			Vector3 dir = (other.transform.position - transform.position).normalized;
			dir *= 300 * Time.fixedDeltaTime;
			other.gameObject.GetComponent<Rigidbody2D>().AddForce(dir, fMode);
			if (other.gameObject.name == "Enemy_T2" || other.gameObject.name == "Enemy_T3")
				other.gameObject.GetComponent<AIEnemy>().HP -= Mathf.Pow(1.5f, PlayerPrefs.GetFloat("MassL"))*PlayerPrefs.GetFloat("Speed");
			else if (other.gameObject.name == "Enemy_T1")
			{
				other.gameObject.GetComponent<Seek2>().HP -= Mathf.Pow(1.5f, PlayerPrefs.GetFloat("MassL"))*PlayerPrefs.GetFloat("Speed");;
			}
			if (other.gameObject.name == "Enemy_T1")
			{
				if (other.gameObject.GetComponent<Seek2>().HP <= 0)
				{
					other.gameObject.GetComponent<Seek2>().Reset();
					other.gameObject.SetActive(false);
				}
			}
			else if (other.gameObject.name == "Enemy_T1" || other.gameObject.name == "Enemy_T2"){
				if (other.gameObject.GetComponent<AIEnemy>().HP <= 0)
				{
					other.gameObject.GetComponent<AIEnemy>().Reset();
					other.gameObject.SetActive(false);
				}
			}
			if (camera.gameObject.GetComponent<JM>().immotal == false)
				PlayerPrefs.SetFloat("HP", PlayerPrefs.GetFloat("HP") - PlayerPrefs.GetFloat("EDamage"));
			PlayEff(Eff.gameObject);
			
		}
	}
}
