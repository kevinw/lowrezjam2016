using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {
	public RectTransform player;
	public RectTransform target;

	public float moveSpeed = 1.0f;
	public float cpuSpeed = 30.0f;

	public Rect playspace;

	void DoPlayerInput() {
		var move = Vector2.zero;
		move += Vector2.right * (Input.GetKey(KeyCode.RightArrow) ? 1.0f : 0.0f);
		move += Vector2.up * (Input.GetKey(KeyCode.UpArrow) ? 1.0f : 0.0f);
		move += Vector2.down * (Input.GetKey(KeyCode.DownArrow) ? 1.0f : 0.0f);
		move += Vector2.left * (Input.GetKey(KeyCode.LeftArrow) ? 1.0f : 0.0f);
		move = move.normalized * moveSpeed * Time.deltaTime;
		player.anchoredPosition = playspace.Clamp(player.anchoredPosition + move);
	}
	
	IEnumerator DoAI() {
		while (true) {
			var playerPos = player.anchoredPosition;
			var myPos = target.anchoredPosition;
			var deltaVec = myPos - playerPos;
			Debug.Log(playerPos + " " + myPos + " " + deltaVec);
			myPos += deltaVec.normalized * cpuSpeed * Time.deltaTime;
			target.anchoredPosition = playspace.Clamp(myPos);
			yield return null;
		}
	}

	void Start() {
		StartCoroutine(DoAI());
	}

	void Update() {
		DoPlayerInput();
	}
}
