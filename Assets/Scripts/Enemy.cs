using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField] GameObject DeathExplosion;
	[SerializeField] Transform SpawnAtRuntimeParent;
	[SerializeField] int ScoreValue = 10;
	Scoreboard Scoreboard;

	private void Start() {
		Scoreboard = FindObjectOfType<Scoreboard>();
	}

	private void OnParticleCollision(GameObject other) {
		GenerateExplosionParticleEffect();
		Destroy(this.gameObject);
		Scoreboard.UpdateScore(ScoreValue);
	}

	private void GenerateExplosionParticleEffect() {
		var deathExplosion = Instantiate(DeathExplosion, transform.position, Quaternion.identity);
		deathExplosion.transform.parent = SpawnAtRuntimeParent;
	}
}
