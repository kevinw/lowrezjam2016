using UnityEngine;
using System.Collections;

public class FlashEnable : MonoBehaviour {

	public MonoBehaviour target;

	public float minValue = 0.0f;
	public float maxValue = 0.1f;

	public float speed = 1.0f;

	void Update () {
		var val = Mathf.Repeat (Time.time * speed, 1.0f);
		target.enabled = minValue < val && val < maxValue;
	}
}
