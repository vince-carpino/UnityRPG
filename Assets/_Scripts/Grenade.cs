using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour {
    private GameObject ExplosionSphere;
    private float CountdownTimer;
    private bool IsFirstCollision = true;

    public float DamageRadius;
    public float Damage;
    public float MinCountdown = 0f;
    public float MaxCountdown = 5f;
    public float DetonationDuration = 1f;

    void Start() {
        CountdownTimer = Random.Range(MinCountdown, MaxCountdown);
        StartCoroutine(DetonateAfterTime(CountdownTimer));
    }

    void FixedUpdate() { }

    void OnCollisionEnter(Collision col) {
        if (IsFirstCollision && col.gameObject.tag.Equals(GameManager.EnemyTag)) {
            Detonate();
        } else {
            IsFirstCollision = false;
        }
    }

    void Detonate() {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        DrawExplosion();

        Collider[] collisions = Physics.OverlapSphere(transform.position, DamageRadius);

        foreach (var col in collisions) {
            if (col.gameObject.tag == GameManager.EnemyTag) {
                col.GetComponent<EnemyController>().TakeDamage(Damage);
            }
        }

        Destroy(ExplosionSphere, DetonationDuration + 0.5f);
        Destroy(gameObject, DetonationDuration + 0.5f);
    }

    void DrawExplosion() {
        ExplosionSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ExplosionSphere.GetComponent<Collider>().isTrigger = true;
        ExplosionSphere.transform.position = gameObject.transform.position;
        StartCoroutine(ScaleOverTime(DetonationDuration));
    }

    IEnumerator DetonateAfterTime(float seconds) {
        yield return new WaitForSeconds(seconds);

        Detonate();
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
