using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour {

    public AudioManager audioManager;
    bool playingStep;

    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    Animator animator;

    void OnEnable() {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;

        animator = GetComponentInChildren<Animator>();

        playingStep = false;
    }

    void Update() {
        timer += Time.deltaTime;

        if (timer >= wanderTimer) {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }

        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("SpeedPercent", speedPercent, 0.125f, Time.deltaTime);

        if (speedPercent > 0.1f && !playingStep) {
            StartCoroutine(playStepSound());
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    IEnumerator playStepSound() {
        playingStep = true;
        string clip = "";
        if (Random.Range(1, 3) == 1)
            clip = "Step1";
        else
            clip = "Step2";
        audioManager.Play(clip);
        yield return new WaitForSeconds(audioManager.FindSound(clip).clip.length * 2);
        playingStep = false;
    }

}
