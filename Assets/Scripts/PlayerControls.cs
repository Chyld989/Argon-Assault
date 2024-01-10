using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
	[SerializeField] float PlayerSpeed = 10f;
	[SerializeField] float MinXLocation = -9f;
	[SerializeField] float MaxXLocation = 9f;
	[SerializeField] float MinYLocation = -5f;
	[SerializeField] float MaxYLocation = 6f;
	[SerializeField] float PositionPitchFactor = 2.5f;
	[SerializeField] float ControlPitchFactor = -10f;
	[SerializeField] float PositionYawFactor = 2f;
	[SerializeField] float ControlRollFactor = -15f;

	[SerializeField] List<GameObject> MachineGuns;

	float XThrow = 0f;
	float YThrow = 0f;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		ProcessPlayerTranslation();
		ProcessPlayerRotation();
		ProcessFiring();
	}

	private void ProcessPlayerTranslation() {
		XThrow = Input.GetAxis("Horizontal");
		YThrow = Input.GetAxis("Vertical");

		var xOffset = XThrow * Time.deltaTime * PlayerSpeed;
		var yOffset = YThrow * Time.deltaTime * PlayerSpeed;

		var newXPosition = transform.localPosition.x + xOffset;
		newXPosition = Mathf.Clamp(newXPosition, MinXLocation, MaxXLocation);

		var newYPosition = transform.localPosition.y + yOffset;
		newYPosition = Mathf.Clamp(newYPosition, MinYLocation, MaxYLocation);

		transform.localPosition = new Vector3(newXPosition, newYPosition, transform.localPosition.z);
	}

	private void ProcessPlayerRotation() {
		var pitch = GetPitch();
		var yaw = GetYaw();
		var roll = GetRoll();

		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}

	private float GetPitch() {
		var pitchDueToPosition = transform.localPosition.y * PositionPitchFactor;
		var pitchDueToControlThrow = YThrow * ControlPitchFactor;
		return pitchDueToPosition + pitchDueToControlThrow;
	}

	private float GetYaw() {
		return transform.localPosition.x * PositionYawFactor;
	}

	private float GetRoll() {
		return XThrow * ControlRollFactor;
	}

	private void ProcessFiring() {
		if (Input.GetButton("Fire1")) {
			SetMachineGunsActive(true);
		} else {
			SetMachineGunsActive(false);
		}
	}

	private void SetMachineGunsActive(bool machineGunActive) {
		foreach (var machineGun in MachineGuns) {
			var emissionModule = machineGun.GetComponent<ParticleSystem>().emission;
			emissionModule.enabled = machineGunActive;
		}
	}
}
