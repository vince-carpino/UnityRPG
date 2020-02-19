using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GrenadeLauncher grenadeLauncher;

    void Update() {
        if (Input.GetButton(GameManager.FireAxisName) && grenadeLauncher.CanFire()) {
            grenadeLauncher.Fire();
        }
    }
}
