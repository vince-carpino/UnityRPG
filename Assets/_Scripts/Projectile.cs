using UnityEngine;

public class Projectile : MonoBehaviour {
    public Rigidbody Rigidbody;

    public float Lifetime;
    public float Speed;
    public float DamageRadius;

    void Start() {
        Rigidbody = gameObject.GetComponent<Rigidbody>();
        Destroy(gameObject, Lifetime);
    }

    void Update() {
    }
}
