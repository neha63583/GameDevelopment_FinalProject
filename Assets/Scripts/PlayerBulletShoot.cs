/**
 * File name: PlayerBulletShoot.cs
 * Author's Name: Neha Arora, Justin Frasca
 * Student Id: 101043939, 101020604
**/
/**This class is to control the movements of the bullet when the player shoots**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletShoot : MonoBehaviour {

	[SerializeField]
	private GameObject bullet;  //declaring a variable of bullet object

	[SerializeField]
	private float bulletForce = 500f;  //force of the bullet 

	private Animator animator = null;
	private Rigidbody2D bulletRigidBody;
	private Transform bulletTransform;

	void Start () {
		animator = gameObject.GetComponent<Animator> ();   //call the animation of the bullet
		bulletTransform = gameObject.transform;          //get the position of the bullet on the screen
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.S)){
			animator.SetTrigger ("shoot");
			ShootBullet ();
		}
	}

	public void ShootBullet(){
		GameObject b = Instantiate (bullet, bulletTransform.position, Quaternion.identity);
		bulletRigidBody = b.GetComponent<Rigidbody2D> ();
		Physics2D.IgnoreCollision (gameObject.GetComponent<Collider2D> (), 
			                       b.GetComponent<Collider2D> ());
		bulletRigidBody.AddForce (bulletTransform.right * bulletForce * bulletTransform.localScale.x);
		b.transform.localScale = bulletTransform.localScale;

	}
}
