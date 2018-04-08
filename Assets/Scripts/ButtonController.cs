using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour {

    [System.Serializable]
    public class ButtonEvent : UnityEvent { }

    public ButtonEvent OnActivate;
    public ButtonEvent OnDeactivate;

    Animator animator;

    void Start() {
        animator = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == tag) {
            animator.SetBool("Activated", true);
            OnActivate.Invoke();
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == tag)  {
            animator.SetBool("Activated", false);
            OnDeactivate.Invoke();
        }
    }
}
