using UnityEngine;

public class ManualAnimation : MonoBehaviour {
	public string animName;
	public float time = 0.0f;

	Animator animator;

	void Awake() {
		animator = GetComponent<Animator>();
		animator.speed = 0.0f;
		animator.Play(animName, 0, 0);
	}

	void Update() {
		float animLength = animator.GetCurrentAnimatorClipInfo(0).Length;
		float animTime = animLength;

		animTime = Mathf.Clamp (animTime, 0, animLength);
		animator.Play(animName, 0, animTime);
	}
}
