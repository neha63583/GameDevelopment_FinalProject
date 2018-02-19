using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {
	
	[SerializeField]
	Text timerDisplay;

	private float gameStartTime;
	private bool finishFlag = false;

	public void Start () {
		gameStartTime = Time.time;
	}
	
	public void Update () {

		if (finishFlag)
			return;
		float gameCurrentTime = Time.time - gameStartTime;
		string timerMinutes = ((int)gameCurrentTime / 60).ToString ();
		string timerSeconds = (gameCurrentTime % 60).ToString ("f2");

		timerDisplay.text = "Timer: " + timerMinutes + ":" + timerSeconds;
	}

	public void FinishTime(){
		finishFlag = true;
		timerDisplay.color = Color.red;
	}
}
