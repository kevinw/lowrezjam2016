using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
	public Vector3 targetPosition;
	public Transform target;
	void Update () {
		if (target)
			transform.LookAt (target.position);
		else
			transform.LookAt (targetPosition);
	}
}
