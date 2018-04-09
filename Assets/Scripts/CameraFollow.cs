using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Vector3 startPos;
    public IsometricCharacterController gameMaster;
    Transform following;
    Transform player;

	void Start () {
        startPos = transform.position;
        following = gameMaster.controlling.transform;
        player = gameMaster.player.transform;
	}

    void Update() {
        if (following != gameMaster.controlling.transform) {
            following = gameMaster.controlling.transform;
        }
    }

    void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position, startPos + (player.position + following.position) / 2, 0.125f);
    }
}
