using UnityEngine;

public class CursorLock : MonoBehaviour {
    [SerializeField]
    private bool Enable = true;

    void Awake() {
        if (Enable) {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
