using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float Health = 100f;

    void FixedUpdate() {
        if (Health <= 0) {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage) {
        Health -= damage;
    }
}
