using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float Health = 100f;

    void Update() {
        if (Health <= 0) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag != "Bullet") {
            return;
        }

        TakeDamage(col.gameObject.GetComponent<Grenade>().Damage);
    }

    public void TakeDamage(float damage) {
        Health -= damage;
    }
}
