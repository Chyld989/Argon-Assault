using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
	[SerializeField] float PlayerSpeed = 10f;
	[SerializeField] float MinXLocation = -9f;
	[SerializeField] float MaxXLocation = 9f;
	[SerializeField] float MinYLocation = -5f;
	[SerializeField] float MaxYLocation = 6f;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		var xThrow = Input.GetAxis("Horizontal");
		var yThrow = Input.GetAxis("Vertical");

		var xOffset = xThrow * Time.deltaTime * PlayerSpeed;
		var yOffset = yThrow * Time.deltaTime * PlayerSpeed;

		var newXPosition = transform.localPosition.x + xOffset;
		newXPosition = Mathf.Clamp(newXPosition, MinXLocation, MaxXLocation);
		var newYPosition = transform.localPosition.y + yOffset;
		newYPosition = Mathf.Clamp(newYPosition, MinYLocation, MaxYLocation);
		var newZPosition = transform.localPosition.z;

		transform.localPosition = new Vector3(newXPosition, newYPosition, newZPosition);
	}
}
