/**
 * File name: ZombieController.cs
 * Author's Name: Neha Arora, Justin Frasca
 * Student Id: 101043939, 101020604
**/
/**This class is to controll the movements of zombie**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour, IDamageable {
	[SerializeField]
	CanvasController canvasController;

	public AudioSource zombieCollideSound;

	[SerializeField]
	private float zombieSpeed = 700f;

	private Rigidbody2D zombieRigidBody;
	private Transform zombieTransform;
	private Animator zombieAnimator;

	private float zombieWidth;
	private float zombieHeight;

	void Start () {
		zombieCollideSound = gameObject.GetComponent<AudioSource> ();
		zombieRigidBody = gameObject.GetComponent<Rigidbody2D> ();
		zombieAnimator = gameObject.GetComponent<Animator> ();
		zombieTransform = gameObject.transform;
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
		zombieWidth = sr.bounds.extents.x;
		zombieHeight = sr.bounds.extents.y;

	}
	
	void FixedUpdate () {
		zombieAnimator.SetTrigger ("walk");
		Vector2 lineCastPosition = (Vector2)zombieTransform.position +
		                           (Vector2)zombieTransform.right * zombieWidth -
		                           (Vector2)zombieTransform.up * zombieHeight;

		Debug.DrawLine (lineCastPosition, lineCastPosition + Vector2.down);
		bool enemyIsGrounded = Physics2D.Linecast (lineCastPosition, lineCastPosition + Vector2.down);
		if(!enemyIsGrounded){
			Vector3 currentRotation = zombieTransform.eulerAngles;
			currentRotation.y += 180;
			zombieTransform.eulerAngles = currentRotation;
		}

		Vector2 zombieVelocity = zombieRigidBody.velocity;
		zombieVelocity.x = zombieTransform.right.x * zombieSpeed;
		zombieRigidBody.velocity = zombieVelocity;
	}

	private int zombieHealth = 2;
	public void Damage(int damage){
		zombieHealth -= damage;
		if (zombieHealth <= 0) {
			zombieAnimator.SetTrigger ("dead");
			Destroy (gameObject, 1);
			canvasController.Score += 20;
		}
	}

	public void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag.Equals ("Player")) {
			IDamageable d = other.gameObject.GetComponent<IDamageable> ();
			d.Damage (20);
		} 
	
		else if (other.gameObject.tag.Equals ("Bullet")) {
			zombieAnimator.SetTrigger ("hurt");
		}

	}
}
