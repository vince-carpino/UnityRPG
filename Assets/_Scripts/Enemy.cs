using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField]
    private float attackRefreshRate = 1.5f;

    private AggroDetection aggroDetection;
    private Health targetHealth;
    private float attackTimer;

    void Awake() {
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;
    }

    void Update() {
        if (targetHealth != null) {
            attackTimer += Time.deltaTime;

            if (CanAttack()) {
                Attack();
            }
        }
    }

    private void AggroDetection_OnAggro(Transform target) {
        Health health = target.GetComponent<Health>();

        if (health != null) {
            targetHealth = health;
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
