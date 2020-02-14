using UnityEngine;

public class Projectile : MonoBehaviour {
    public Rigidbody Rigidbody;

    void Start() {
        Rigidbody = gameObject.GetComponent<Rigidbody>();
    }
}
