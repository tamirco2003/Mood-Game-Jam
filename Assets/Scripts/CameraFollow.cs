using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Vector3 startPos;
    public IsometricCharacterController charControl;
    
    public Transform following;
    public Transform player;

	void Start () {
        startPos = transform.position;
        following = charControl.controlling.transform;
        player = charControl.transform;
	}

    void Update() {
        if (following != charControl.controlling.transform) {
            following = charControl.controlling.transform;
        }
        if (player != charControl.transform) {
            player = charControl.transform;
        }
    }

    void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position, startPos + (player.position + following.position) / 2, 0.125f);
    }
}
