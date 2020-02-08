using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Weapon Weapon;

    void Update() {
        if (Input.GetMouseButtonDown(0) && Weapon.CanFire()) {
            Weapon.Fire();
        }
    }
}
