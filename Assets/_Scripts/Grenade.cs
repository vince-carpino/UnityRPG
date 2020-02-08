using UnityEngine;

public class Grenade : MonoBehaviour {
    public float Lifetime;

    void Start() {
        
    }

    void Update() {
        Destroy(gameObject, Lifetime);
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag != "Ground") {
            return;
        }

        Detonate();
    }

    void Detonate() {
        Destroy(gameObject);
    }
}
