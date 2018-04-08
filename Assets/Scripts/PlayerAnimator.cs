using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    IsometricCharacterController charControl;
    Animator animator;
    Rigidbody rb;

	void Start () {
        charControl = GetComponent<IsometricCharacterController>();
        animator = charControl.GetComponentInChildren<Animator>();
        rb = charControl.GetComponentInChildren<Rigidbody>();
	}
	
	void Update () {
        float speedPercent = rb.velocity.magnitude / charControl.moveSpeed;
        animator.SetFloat("SpeedPercent", speedPercent, 0.125f, Time.deltaTime);
	}
}
