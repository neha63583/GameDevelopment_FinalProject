/**
 * File name: EndZone.cs
 * Author's Name: Neha Arora, Justin Frasca
 * Student Id: 101043939, 101020604
**/
/**This class is to define the boundaries of the game i.e., kill zone or end zone**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour {

	[SerializeField]
	Transform spawnPoint = null;

	public void OnCollisionEnter2D(Collision2D other){
		other.transform.position = spawnPoint.position;
		Rigidbody2D rigidBody = other.gameObject.GetComponent<Rigidbody2D> ();
		if (rigidBody) {
			rigidBody.velocity = Vector2.zero;
		}
	}

}
