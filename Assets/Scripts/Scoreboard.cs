using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour {
	int PlayerScore;
	TMP_Text PlayerScoreOnScoreboard;

	private void Start() {
		PlayerScoreOnScoreboard = GetComponent<TMP_Text>();
		PlayerScoreOnScoreboard.text = $@"Score: {PlayerScore}";
	}

	public void UpdateScore(int scoreModifier) {
		PlayerScore += scoreModifier;
		PlayerScoreOnScoreboard.text = $@"Score: {PlayerScore}";
	}
}
