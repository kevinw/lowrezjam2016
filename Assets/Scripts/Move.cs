using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public float period = 3.0f;
	public float radius = -10f;
	public float y;
	public MoveType moveType = MoveType.InCircle;

	public enum MoveType {
		InCircle
	}

	void Update () {
		if (moveType == MoveType.InCircle) {
			float radians = 2f * Mathf.PI * (Time.time / period);
			transform.localPosition = new Vector3 (Mathf.Sin (radians) * radius, y, Mathf.Cos (radians) * radius);
		}
	
	}
}
