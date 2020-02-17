using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Weapon Weapon;

    void Update() {
        if (Input.GetAxis(GameManager.FireAxisName) > 0 && Weapon.CanFire()) {
            Weapon.Fire();
        }
    }
}
