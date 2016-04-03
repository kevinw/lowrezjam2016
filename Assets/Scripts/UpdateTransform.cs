using UnityEngine;
using System.Collections;

public class UpdateTransform : MonoBehaviour {

	public Vector3 rotationDelta;

	void Update () {
		transform.Rotate (rotationDelta * Time.deltaTime);
	}
}
