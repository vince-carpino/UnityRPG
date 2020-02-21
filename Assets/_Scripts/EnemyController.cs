using UnityEngine;

public class EnemyController : MonoBehaviour {
    private float Health = 100f;

    public void TakeDamage(float damage) {
        Health -= damage;

        if (Health <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
