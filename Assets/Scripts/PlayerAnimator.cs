using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    public AudioManager audioManager;
    bool playingStep;

    IsometricCharacterController charControl;
    Animator animator;
    Rigidbody rb;

	void Start () {
        charControl = GetComponent<IsometricCharacterController>();
        animator = charControl.GetComponentInChildren<Animator>();
        rb = charControl.GetComponentInChildren<Rigidbody>();
        playingStep = false;
	}
	
	void Update () {
        float speedPercent = rb.velocity.magnitude / charControl.moveSpeed;
        animator.SetFloat("SpeedPercent", speedPercent, 0.125f, Time.deltaTime);


        if (speedPercent > 0.1f && !playingStep) {
            StartCoroutine(playStepSound());
        }
    }

    IEnumerator playStepSound() {
        playingStep = true;
        string clip = "";
        if (Random.Range(1, 3) == 1)
            clip = "Step1";
        else
            clip = "Step2";
        audioManager.PlayOnce(clip);
        yield return new WaitForSeconds(audioManager.FindSound(clip).clip.length);
        playingStep = false;
    }
}
