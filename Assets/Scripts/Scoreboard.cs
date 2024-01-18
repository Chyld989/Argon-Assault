using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour {
	int playerScore;

	private void Start() {
		Debug.Log($@"Player score is now {playerScore}");
	}

	public void UpdateScore(int scoreModifier) {
		playerScore += scoreModifier;
		Debug.Log($@"Player score is now: {playerScore}");
	}
}
