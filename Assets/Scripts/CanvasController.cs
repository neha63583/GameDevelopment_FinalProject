/**
 * File name: CanvasController.cs
 * Author's Name: Neha Arora, Justin Frasca
 * Student Id: 101043939, 101020604
**/
/**This class is to control the functions of canvas**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {

	[SerializeField]
	Text scoreLabel;

	[SerializeField]
	Text robotHealthLabel;

	[SerializeField]
	Text gameOverLabel;

	[SerializeField]
	Text highScoreLabel;

	[SerializeField]
	Text gameTitleLabel;

	[SerializeField]
	Text timerLabel;

	[SerializeField]
	Text level1CompletedLabel;

	[SerializeField]
	Button playAgainBtn;

	[SerializeField]
	Button playBtn;

	[SerializeField]
	GameObject coin;

	[SerializeField]
	GameObject zombie;

	[SerializeField]
	TimerController timerController;

	private int score = 0;   //default score
	private int robotHealth = 100;   //default health = 100%

	public int Score{
		get{ return score;}
		set{ score = value;
			scoreLabel.text = "Score: " + score;}
	}

	public int RobotHealth{
		get{ return robotHealth;}
		set{
			robotHealth = value;
			if (robotHealth <= 0) {
				gameOver ();} 
			else {
				robotHealthLabel.text = "Health: " + robotHealth + "%";}
		   }
    }
		

	void Start () {
		initializeFirstPage ();
	}
	
	public void gameOver () {
		gameOverLabel.gameObject.SetActive (true);
		highScoreLabel.gameObject.SetActive (true);
		playAgainBtn.gameObject.SetActive (true);

		robotHealthLabel.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (false);
		gameTitleLabel.gameObject.SetActive (false);
		timerLabel.gameObject.SetActive (false);
		playBtn.gameObject.SetActive (false);
		level1CompletedLabel.gameObject.SetActive (false);

		highScoreLabel.text = "High Score: " + Score;
	}

	private void initializeFirstPage(){
		gameOverLabel.gameObject.SetActive (false);
		highScoreLabel.gameObject.SetActive (false);
		playAgainBtn.gameObject.SetActive (false);
		robotHealthLabel.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (false);
		timerLabel.gameObject.SetActive (false);
		coin.gameObject.SetActive (false);
		zombie.gameObject.SetActive (false);
		level1CompletedLabel.gameObject.SetActive (false);

		gameTitleLabel.gameObject.SetActive (true);
		playBtn.gameObject.SetActive (true);
	}

	private void initializeCanvas(){
		score = 0;
		robotHealth = 100;
		scoreLabel.text = "Score: " + score;
		robotHealthLabel.text = "Health: " + robotHealth + "%";

		gameOverLabel.gameObject.SetActive (false);
		highScoreLabel.gameObject.SetActive (false);
		playAgainBtn.gameObject.SetActive (false);
		level1CompletedLabel.gameObject.SetActive (false);

		robotHealthLabel.gameObject.SetActive (true);
		scoreLabel.gameObject.SetActive (true);
		timerLabel.gameObject.SetActive (true);
		coin.gameObject.SetActive (true);
		zombie.gameObject.SetActive (true);

		gameTitleLabel.gameObject.SetActive (false);
		playBtn.gameObject.SetActive (false);
	}

	public void PlayBtnClick(){
		initializeCanvas();
	}

	public void PlayAgainBtnClick(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
		
	public void LevelOneCompleted(){
		
		gameOverLabel.gameObject.SetActive (false);
		playAgainBtn.gameObject.SetActive (false);
		robotHealthLabel.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (false);
		gameTitleLabel.gameObject.SetActive (false);
		playBtn.gameObject.SetActive (false);
		coin.gameObject.SetActive (false);
		zombie.gameObject.SetActive (false);

		level1CompletedLabel.gameObject.SetActive (true);
		timerLabel.gameObject.SetActive (true);
		highScoreLabel.gameObject.SetActive (true);
		highScoreLabel.text = "HIGH SCORE: " + Score;
	}

	public void LevelTwoCompleted(){
		gameOverLabel.gameObject.SetActive (false);
		playAgainBtn.gameObject.SetActive (false);
		robotHealthLabel.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (false);
		gameTitleLabel.gameObject.SetActive (false);
		playBtn.gameObject.SetActive (false);
		coin.gameObject.SetActive (false);
		zombie.gameObject.SetActive (false);

		level1CompletedLabel.gameObject.SetActive (true);
		timerLabel.gameObject.SetActive (true);
		highScoreLabel.gameObject.SetActive (true);
		playAgainBtn.gameObject.SetActive (true);
		highScoreLabel.text = "HIGH SCORE: " + Score;

	}
}
