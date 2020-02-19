using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField]
    private float attackRefreshRate = 1.5f;

    private AggroDetection aggroDetection;
    private Health targetHealth;
    private float attackTimer;

    private void Awake() {
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;
    }

    private void AggroDetection_OnAggro(Transform target) {
        Health health = target.GetComponent<Health>();

        if (health != null) {
            targetHealth = health;
        }
    }

    void Update() {
        if (targetHealth != null) {
            attackTimer += Time.deltaTime;

            if (CanAttack()) {
                Attack();
            }
        }
    }

    private bool CanAttack() {
        return attackTimer >= attackRefreshRate;
    }

    private void Attack() {
        attackTimer = 0;

        targetHealth.TakeDamage(1);
    }
}
