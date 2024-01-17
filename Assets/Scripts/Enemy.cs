using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField] GameObject DeathExplosion;
	[SerializeField] Transform SpawnAtRuntimeParent;

	private void OnParticleCollision(GameObject other) {
		var deathExplosion = Instantiate(DeathExplosion, transform.position, Quaternion.identity);
		deathExplosion.transform.parent = SpawnAtRuntimeParent;
		Destroy(this.gameObject);
	}
}
