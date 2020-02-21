using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private AggroDetection aggroDetection;
    private Transform target;

    void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;
    }

    void Update() {
        if (target != null) {
            navMeshAgent.SetDestination(target.position);
            float currentSpeed = navMeshAgent.velocity.magnitude;
            animator.SetFloat("Speed", currentSpeed);
        }
    }

    private void AggroDetection_OnAggro(Transform target) {
        this.target = target;
    }
}
