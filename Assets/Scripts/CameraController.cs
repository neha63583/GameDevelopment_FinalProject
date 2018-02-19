/**
 * File name: CameraController.cs
 * Author's Name: Neha Arora, Justin Frasca
 * Student Id: 101043939, 101020604
**/
/**This class is to make the camera follow the player robot**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField]
	Transform targetPlayer = null;

	//to make the camera position same as the player
	void Update () {
		gameObject.transform.position = new Vector3 (targetPlayer.position.x,
			                                         targetPlayer.position.y,
			                                         gameObject.transform.position.z);
	}
}
