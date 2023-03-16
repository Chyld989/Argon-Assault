using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterRotors : MonoBehaviour {
	[Header("Rotor Parameters")]
	[SerializeField] bool RotateRotors = true;
	[SerializeField] bool RotateRotorsCounterClockwise = true;
	[SerializeField] float DegreesRotatedPerSecond = 1080f;
	[Header("Rotor Objects")]
	[SerializeField] GameObject MainRotor = default;
	[SerializeField] GameObject TailRotor1 = default;
	[SerializeField] GameObject TailRotor2 = default;

	// Update is called once per frame
	void Update() {
		if (RotateRotors) {
			var degreesToRotate = DegreesRotatedPerSecond * Time.deltaTime;
			if (RotateRotorsCounterClockwise) {
				degreesToRotate *= -1;
			}
			MainRotor.transform.Rotate(new Vector3(0f, degreesToRotate, 0f));
			degreesToRotate *= -1;
			TailRotor1.transform.Rotate(new Vector3(degreesToRotate, 0f, 0f));
			TailRotor2.transform.Rotate(new Vector3(degreesToRotate, 0f, 0f));
		}
	}
}
