using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Weapon Weapon;

    void Start() {
        
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Weapon.Fire();
        }
    }
}
