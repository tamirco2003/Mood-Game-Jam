using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour {

    public Collider activator;

    [System.Serializable]
    public class ButtonEvent : UnityEvent { }

    public ButtonEvent OnActivate;
    public ButtonEvent OnDeactivate;

    Animator animator;

    void Start() {
        animator = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter(Collider other) {
        if (other == activator) {
            animator.SetBool("Activated", true);
            OnActivate.Invoke();
        }
    }

    void OnTriggerExit(Collider other) {
        if (other == activator) {
            animator.SetBool("Activated", false);
            OnDeactivate.Invoke();
        }
    }
}
