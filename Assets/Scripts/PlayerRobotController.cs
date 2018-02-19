/**
 * File name: PlayerRobotController.cs
 * Author's Name: Neha Arora, Justin Frasca
 * Student Id: 101043939, 101020604
**/
/**This class is to control the movements of the player(Robot)**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRobotController : MonoBehaviour, IDamageable {

	[SerializeField]
	private float playerSpeed = 500f;
	[SerializeField]
	private float playerJumpMultiplier = 100f;

	[SerializeField]
	private float playerStartX = -2300f;
	[SerializeField]
	private float playerEndX = 10300f;

	private Rigidbody2D playerRigidBody = null;
	private Animator playerAnimator = null;
	private Vector2 playerCurrentPosition;
	private Transform playerTransform;

	private int playerHealth = 100;
	public bool deadFlag = false;

	void Start () {
		playerAnimator = gameObject.GetComponent<Animator> ();
		playerRigidBody = gameObject.GetComponent<Rigidbody2D> ();
		playerTransform = gameObject.GetComponent<Transform> ();
		playerCurrentPosition = playerTransform.position;
		
	}

	void FixedUpdate () {

		if (!deadFlag)   //if player is not dead then let him do other functions otherwise not
		{
			playerCurrentPosition = playerTransform.position;
			//To make player run
			float moveHorizontal = Input.GetAxis ("Horizontal");
			playerRigidBody.velocity = new Vector2 (moveHorizontal * playerSpeed, playerRigidBody.velocity.y);


			//To make player jump press space
			float playerJump = Input.GetAxis ("Jump");
			if (playerJump > 0 && IsPlayerGrounded ()) {
				playerRigidBody.AddForce (Vector2.up * playerJumpMultiplier);
			}

			playerAnimator.SetInteger ("velocity", (int)(Mathf.Abs (playerRigidBody.velocity.x * 100)));


			//To make player turn left and right
			if (playerRigidBody.velocity.x > 0) {
				gameObject.transform.localScale = new Vector3 (1, 1, 1);
			} else if (playerRigidBody.velocity.x < 0) {
				gameObject.transform.localScale = new Vector3 (-1, 1, 1);
			} 

			playerAnimator.SetBool ("jump", !IsPlayerGrounded ());

			//To make player shoot:
			//in PlayerBuletShoot Script
		}

		CheckPlayerBoundaries ();
		playerTransform.position = playerCurrentPosition;

	}

	private bool IsPlayerGrounded(){
		SpriteRenderer playerSR = gameObject.GetComponent<SpriteRenderer> ();
		Vector2 playerPos = gameObject.transform.position;

		RaycastHit2D res = Physics2D.Linecast (new Vector2 (playerPos.x, playerPos.y - (playerSR.bounds.size.y / 2)),
			                                   new Vector2 (playerPos.x, playerPos.y - (playerSR.bounds.size.y / 2 + 0.2f)));

		Debug.DrawLine (new Vector2 (playerPos.x, playerPos.y - (playerSR.bounds.size.y / 2)),
			            new Vector2 (playerPos.x, playerPos.y - (playerSR.bounds.size.y / 2 + 0.2f)));

		return res != null && res.collider != null;
	}

	public void Damage(int damage){
		playerHealth -= damage;
		if (playerHealth <= 0) {
			deadFlag = true;
			playerAnimator.SetBool ("dead", deadFlag);
		}
	}

	private void CheckPlayerBoundaries(){        //check if player is going out of boundaries
		if (playerCurrentPosition.x > playerEndX) {     
			playerCurrentPosition.x = playerEndX;
		}

		else if (playerCurrentPosition.x < playerStartX) {     
			playerCurrentPosition.x = playerStartX;
		}
	}
}
