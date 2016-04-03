using UnityEngine;
using System.Collections;

public class TriggerVibrate : MonoBehaviour {

	public MonoBehaviour target;

	public KeyCode onKeyCode = KeyCode.None;

	void Update () {
		if (onKeyCode != KeyCode.None)
			target.enabled = Input.GetKey (onKeyCode);
	}
}
