using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour {
    private GameObject ExplosionSphere;

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
        DrawExplosion();

        Collider[] collisions = Physics.OverlapSphere(transform.position, DamageRadius);

        foreach (var col in collisions) {
            if (col.gameObject.tag == "Enemy") {
                col.GetComponent<EnemyController>().TakeDamage(Damage);
            }
        }
    }

    void DrawExplosion() {
        ExplosionSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ExplosionSphere.GetComponent<Collider>().isTrigger = true;
        ExplosionSphere.transform.position = gameObject.transform.position;
        StartCoroutine(ScaleOverTime(0.15f));
    }

    IEnumerator ExecuteAfterTime(float seconds) {
        yield return new WaitForSeconds(seconds);

        Destroy(ExplosionSphere);
        Destroy(gameObject);
    }

    IEnumerator ScaleOverTime(float time) {
        Vector3 originalScale = Vector3.zero;
        Vector3 destinationScale = new Vector3(DamageRadius, DamageRadius, DamageRadius);

        float currentTime = 0.0f;

        do {
            ExplosionSphere.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        Destroy(ExplosionSphere);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DamageRadius);
    }
}
