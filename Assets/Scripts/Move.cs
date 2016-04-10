using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public float radians;
	public float period = 3.0f;
	public float radius = -10f;
	public float y;

	public float RotateSpeed;
	public float IncreaseSpeed = 1.0f;
	public float DecreaseSpeed = 0.5f;
	public float MinRotateSpeed = 1.0f;
	public float MaxRotateSpeed = 50.0f;

	void Update () {
		RotateSpeed += Game.Instance.ExciteProximityFactor * IncreaseSpeed;
		RotateSpeed -= DecreaseSpeed;
		RotateSpeed = Mathf.Clamp (RotateSpeed, MinRotateSpeed, MaxRotateSpeed);
		radians += Time.deltaTime * RotateSpeed;
		transform.localPosition = new Vector3 (Mathf.Sin (radians) * radius, y, Mathf.Cos (radians) * radius);
	}
}
