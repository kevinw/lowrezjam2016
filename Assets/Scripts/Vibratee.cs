using UnityEngine;
using System.Collections;

public class Vibratee : MonoBehaviour {
	public float excitement = 0.0f;

	public float exciteFactor = 1.0f;
	public float calmFactor = 0.8f;

	Vibrate vibrate;

	void Awake() { 
		vibrate = GetComponent<Vibrate>();
	}

	public void Excite() {
		excitement += Time.deltaTime * exciteFactor;
	}

	public void Update() {
		excitement -= Time.deltaTime * calmFactor;
		excitement = Mathf.Max(0, excitement);

		vibrate.enabled = true;
		vibrate.amount = excitement;
	}

}
