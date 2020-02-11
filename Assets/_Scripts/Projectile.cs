using UnityEngine;

public class Projectile : MonoBehaviour {
    public Rigidbody Rigidbody;
    public float DamageRadius;

    void Start() {
        Rigidbody = gameObject.GetComponent<Rigidbody>();
    }
}
