using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCharacterController : MonoBehaviour {

    public GameObject player;
    public GameObject controlling;

    Rigidbody rb;

    [Range(0, 20)]
    public float moveSpeed = 5;

    [Range(0, 20)]
    public float controlDistance = 5;

    Vector3 isoForward;

    float timeCounter;

    Vector3 origin;

    void Start() {
        rb = controlling.GetComponent<Rigidbody>();

        isoForward = Camera.main.transform.forward;
        isoForward.y = 0;
        isoForward = isoForward.normalized;

        timeCounter = 0;
        origin = Vector3.zero;
    }

    void Update() {
        if (controlling == player) {
            MovePlayer(moveSpeed);
        }
        else {
            Telepathy(moveSpeed);
            timeCounter += Time.deltaTime;

            if (Vector3.Distance(controlling.transform.position, player.transform.position) > controlDistance) {
                timeCounter = 0;
                controlling = player;
                rb = controlling.GetComponent<Rigidbody>();
                origin = Vector3.zero;
            }
        }

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Controllable"))) {
                if (Vector3.Distance(hit.transform.position, player.transform.position) <= controlDistance) {
                    timeCounter = 0;
                    controlling = hit.collider.gameObject;
                    rb = controlling.GetComponent<Rigidbody>();
                    origin = controlling.transform.position;
                }
            }
        }
        
        if (Input.GetMouseButtonDown(1)) {
            timeCounter = 0;
            controlling = player;
            rb = controlling.GetComponent<Rigidbody>();
            origin = Vector3.zero;
        }
    }

    void Telepathy(float speed) {
        Vector3 moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveVector = Quaternion.FromToRotation(Vector3.forward, isoForward) * moveVector * speed;

        rb.velocity = moveVector;

        Vector3 pos = controlling.transform.position;
        float difference = Mathf.Sin(timeCounter * 3) / 5 + 1;
        pos.y = Mathf.Lerp(pos.y, origin.y + difference, 0.125f);
        controlling.transform.position = pos;

        pos.y = player.transform.position.y;

        player.transform.LookAt(pos);
    }

    void MovePlayer(float speed) {
        Vector3 moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveVector = Quaternion.FromToRotation(Vector3.forward, isoForward) * moveVector * speed;

        Vector3 direction = moveVector.normalized;
        if (direction != Vector3.zero)
            controlling.transform.forward = direction;

        moveVector.y = rb.velocity.y;

        rb.velocity = moveVector;
    }
}
