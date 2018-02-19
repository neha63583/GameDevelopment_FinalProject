/**
 * File name: PlayerCollider.cs
 * Author's Name: Neha Arora, Justin Frasca
 * Student Id: 101043939, 101020604
**/
/**This class is to control what happens when player collides with coins and zombies**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour {

	[SerializeField]
	CanvasController canvasController;

	[SerializeField]
	ZombieController zombieController;

	[SerializeField]
	TimerController timerController;

	private AudioSource coinScoreSound;

	void Start () {
		coinScoreSound = gameObject.GetComponent<AudioSource> ();
	}
	
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals ("Coin")) 
		{
			Debug.Log ("Collision detected with the coin :)\n");
			if (coinScoreSound != null) {
				coinScoreSound.Play ();}
			Destroy (other.gameObject);
			canvasController.Score += 10;
		}

		if(other.gameObject.tag.Equals ("LevelEndCollider"))
		{
			Debug.Log ("Congratulations Level 1 Completed:)\n");
			canvasController.LevelOneCompleted ();
			timerController.FinishTime ();
			StartCoroutine ("LoadLevel2");

		}

		if(other.gameObject.tag.Equals ("Level2EndCollider"))
		{
			Debug.Log ("Congratulations Level 2 Completed:)\n");
			canvasController.LevelTwoCompleted ();
			timerController.FinishTime ();

		}


	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag.Equals ("Enemy")) {
			Debug.Log ("Collision detected with the enemy :(\n");
			if (zombieController.zombieCollideSound != null) {
				zombieController.zombieCollideSound.Play ();}
			canvasController.RobotHealth -= 20;
			StartCoroutine ("Blink");
		}

		else if (other.gameObject.tag.Equals ("Bullet")) {
			Debug.Log ("Player Shooting  :)\n");
		}

		else if(other.gameObject.tag.Equals("KillZone")){
			Debug.Log ("Player fell :(10% health lost!!\n");
			canvasController.RobotHealth -= 10;
			//timerController.Start();
		}
	}

	private IEnumerator Blink()
	{
		Color robotColor;
		Renderer rend = gameObject.GetComponent<Renderer> ();
		for (int blinkTime = 0; blinkTime < 2; blinkTime++) 
		{
			for (float f = 1f; f >= 0; f -= 0.1f) {
				robotColor = rend.material.color;
				robotColor.a = f;
				rend.material.color = robotColor;
				yield return new WaitForSeconds (0.01f);
			}
			for (float f = 0f; f <= 1; f += 0.1f) {
				robotColor = rend.material.color;
				robotColor.a = f;
				rend.material.color = robotColor;
				yield return new WaitForSeconds (0.01f);
			}
		}
	}

	IEnumerator LoadLevel2()
	{
		yield return new WaitForSeconds(3.0f);
		SceneManager.LoadScene ("Level02");
	}
}


