/**
 * File name: BulletScript.cs
 * Author's Name: Neha Arora, Justin Frasca
 * Student Id: 101043939, 101020604
**/
/**This class is to control the movements of the bullet**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	[SerializeField]
	int damage = 5;

	void Start () {
		StartCoroutine ("Finish");
	}

	void OnCollisionEnter2D(Collision2D other){
		IDamageable d = other.gameObject.GetComponent<IDamageable> ();
		if(d != null){
			d.Damage (damage);
	    }
		Destroy (gameObject);
   }

	private IEnumerator Finish(){
		yield return new WaitForSeconds (5);
		Destroy (gameObject);
	}
}
   
public interface IDamageable{
	void Damage (int damage);
}
