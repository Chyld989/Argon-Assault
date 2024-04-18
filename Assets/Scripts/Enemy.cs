using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField] GameObject DeathExplosion;
	[SerializeField] GameObject MachineGunExplosion;
	[SerializeField] GameObject RocketExplosion;
	[SerializeField] int ScoreValue = 10;
	[SerializeField] int EnemyHealth = 3;
	Scoreboard Scoreboard;
	GameObject SpawnAtRuntimeParent;

	private void Start() {
		Scoreboard = FindObjectOfType<Scoreboard>();
		SpawnAtRuntimeParent = GameObject.FindWithTag("Spawn At Runtime");
		var rigidbody = gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
	}

	private void OnParticleCollision(GameObject other) {
		DamageEnemy(1);
		GenerateMachineGunHitExplosionParticleEffect(other);
		if (EnemyHealth <= 0) {
			KillEnemy();
		}
	}

	private void DamageEnemy(int damageAmount) {
		EnemyHealth -= damageAmount;
	}

	private void GenerateMachineGunHitExplosionParticleEffect(GameObject hitBy) {
		// Start with the enemy's position just in case the particle's position can't be found for some reason
		var hitLocation = this.transform.position;
		// Get particle system that fired the particle
		ParticleSystem particleSystem = null;
		foreach (var curParticleSystem in hitBy.GetComponentsInChildren<ParticleSystem>()) {
			if (curParticleSystem.gameObject.name == hitBy.gameObject.name) {
				particleSystem = curParticleSystem;
				break;
			}
		}
		if (particleSystem != null) {
			// Loop through the collision events to get the particle's position
			var collisionEvents = new List<ParticleCollisionEvent>();
			var collisionEventCount = particleSystem.GetCollisionEvents(gameObject, collisionEvents);
			for (int i = 0; i < collisionEventCount; i++) {
				hitLocation = collisionEvents[i].intersection;
			}
			// Instantiate the explosion
			var machineGunExplosion = Instantiate(MachineGunExplosion, hitLocation, Quaternion.identity);
			machineGunExplosion.transform.parent = SpawnAtRuntimeParent.transform;
		}
	}

	private void KillEnemy() {
		GenerateDeathExplosionEffects();
		Destroy(this.gameObject);
		Scoreboard.UpdateScore(ScoreValue);
	}

	private void GenerateDeathExplosionEffects() {
		var deathExplosion = Instantiate(DeathExplosion, this.transform.position, Quaternion.identity);
		deathExplosion.transform.parent = SpawnAtRuntimeParent.transform;
	}
}
