using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {
	[SerializeField] GameObject PlayerControlStartPlane;

	[Header("Win/Lose Settings")]
	[SerializeField] float SceneResetTimerInSeconds = 3.0f;

	PlayerControls PlayerControls;

	private void Start() {
		PlayerControls = GetComponent<PlayerControls>();
		PlayerControlStartPlane.GetComponent<MeshRenderer>().enabled = false; ;
		PlayerControls.AdjustPlayerControl(false);
	}

	private void OnTriggerEnter(Collider other) {
		//Debug.Log($@"{this.name} triggered by {other.gameObject.name}.");
		if (other.gameObject.name == "PlayerControlStartPlane") {
			PlayerControls.AdjustPlayerControl(true);
		} else {
			StartCrashSequence();
		}
	}

	public void StartCrashSequence() {
		PlayerControls.AdjustPlayerControl(false);
		StartCoroutine(ReloadSceneAfterDelay(SceneResetTimerInSeconds));
	}

	IEnumerator ReloadSceneAfterDelay(float delay) {
		yield return new WaitForSeconds(delay);

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
