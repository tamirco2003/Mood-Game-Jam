using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    Vector3 origin;
    public Vector3 offset;

    void Start() {
        origin = transform.position;
    }

    public void Move(bool back) {
        StopAllCoroutines();
        if (!back)
            StartCoroutine(MoveTo());
        else
            StartCoroutine(MoveBack());
    }

    IEnumerator MoveTo() {
        while (Vector3.Distance(transform.position, origin + offset) > 0.1) {
            transform.position = Vector3.Lerp(transform.position, origin + offset, 0.02f);
            yield return null;
        }
    }

    IEnumerator MoveBack() {
        while (Vector3.Distance(transform.position, origin) > 0.1) {
            transform.position = Vector3.Lerp(transform.position, origin, 0.02f);
            yield return null;
        }
    }
}
