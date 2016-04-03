using UnityEngine;
using System.Collections;

public class Vibrate : MonoBehaviour {

	public float amount = 1.0f;

	public Vibratee target;

	public Vector3 originalPos;

	void OnEnable() {
		originalPos = transform.position;
	}

	void OnDisable() {
		transform.position = originalPos;
	}

	void Update () {
		Vector3 vibration = Random.insideUnitSphere * amount;
		transform.position = originalPos + vibration;
		if (target != null)
			target.Excite ();
	}
}
