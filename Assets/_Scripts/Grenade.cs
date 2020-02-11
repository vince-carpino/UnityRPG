using UnityEngine;

public class Grenade : MonoBehaviour {
    public float Lifetime;
    public float DamageRadius;
    public float Damage;

    void Start() {
        Destroy(gameObject, Lifetime);
    }

    void OnCollisionEnter(Collision col) {
        switch (col.gameObject.tag) {
            case "Ground":
                Detonate();
                break;
            case "Enemy":
                Detonate();
                break;
            default:
                break;
        }
    }

    void Detonate() {
        Collider[] collisions = Physics.OverlapSphere(transform.position, DamageRadius);
        print(collisions.Length);

        foreach (var col in collisions) {
            if (col.gameObject.tag == "Enemy") {
                col.GetComponent<EnemyController>().TakeDamage(Damage);
            }
        }

        Destroy(gameObject);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DamageRadius);
    }
}
