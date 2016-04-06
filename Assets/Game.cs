using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {
	public static Game Instance;

	public RectTransform player;
	public RectTransform target;
	public float moveSpeed = 1.0f;
	public Rect playspace;

	void Awake() {
		Instance = this;
	}

	void Update() {
		DoPlayerInput();
	}

	void DoPlayerInput() {
		var move = Vector2.zero;
		move += Vector2.right * (Input.GetKey(KeyCode.RightArrow) ? 1.0f : 0.0f);
		move += Vector2.up * (Input.GetKey(KeyCode.UpArrow) ? 1.0f : 0.0f);
		move += Vector2.down * (Input.GetKey(KeyCode.DownArrow) ? 1.0f : 0.0f);
		move += Vector2.left * (Input.GetKey(KeyCode.LeftArrow) ? 1.0f : 0.0f);
		move = move.normalized * moveSpeed * Time.deltaTime;
		player.anchoredPosition = playspace.Clamp(player.anchoredPosition + move);
	}

}
