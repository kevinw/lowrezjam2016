using UnityEngine;
using System.Collections;

public class TriggerVibrate : MonoBehaviour {

	public MonoBehaviour target;

	void Update () {
		target.enabled = Input.GetKey (KeyCode.Space);
	}
}
