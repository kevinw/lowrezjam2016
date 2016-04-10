using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {
	public static Game Instance;

	public float excitement = 0.0f;
	public RectTransform player;
	public Partner partner;
	public float moveSpeed = 1.0f;
	public Rect playspace;
	public float minExciteDistance = 1.0f;
	public float exciteFactor = 1.0f;
	public AnimationCurve exciteCurve;
	public Text debugText;

	public Animator animator;

	void Awake() {
		Instance = this;
		animator.speed = 0.0f;
	}

	void Update() {
		DoPlayerInput();
		DoExcite();
		DoGUI();
		ScrubAnimation();
	}

	enum Action {
		Right, Up, Down, Left
	}

	bool Pressed(Action action) {
		switch (action) {
			case Action.Up:
				return Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
			case Action.Left:
				return Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
			case Action.Down:
				return Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
			case Action.Right:
				return Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
			default:
				throw new System.Exception("unknown action " + action);
		}
	}

	void DoPlayerInput() {
		var move = Vector2.zero;
		move += Vector2.right * (Pressed(Action.Right) ? 1.0f : 0.0f);
		move += Vector2.up * (Pressed(Action.Up) ? 1.0f : 0.0f);
		move += Vector2.down * (Pressed(Action.Down) ? 1.0f : 0.0f);
		move += Vector2.left * (Pressed(Action.Left) ? 1.0f : 0.0f);
		move = move.normalized * moveSpeed * Time.deltaTime;
		player.anchoredPosition = playspace.Clamp(player.anchoredPosition + move);
	}

	public float ExciteProximityFactor { get {
		float factor = 0;
		var playerPos = player.anchoredPosition;
		var partnerPos = partner.Position;

		var distance = Vector2.Distance(playerPos, partnerPos);
		if (distance <= minExciteDistance) {
			factor = 1.0f - distance / minExciteDistance;
			//factor = exciteCurve.Evaluate(factor);
		}

		return factor;
	} }

	void DoExcite() {
		excitement += ExciteProximityFactor * exciteFactor * Time.deltaTime;
	}

	void DoGUI() {
		if (debugText)
			debugText.text = excitement.ToString();
	}

	 public AnimationClip GetAnimationClip(string name) {
		 foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
			 if (clip.name == name)
				 return clip;

		 return null;
	 }

	void ScrubAnimation() {
		const int layerIndex = 0;
		var stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
		animator.Play(stateInfo.fullPathHash, layerIndex, excitement);
		if (excitement > 1) {
			animator.SetTrigger("next");
			var nextState = animator.GetNextAnimatorStateInfo(layerIndex);
			animator.Play(nextState.fullPathHash);
			excitement = 0;
		}
	}
}
