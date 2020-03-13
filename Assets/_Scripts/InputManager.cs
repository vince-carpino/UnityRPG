using UnityEngine;

public class InputManager : MonoBehaviour {
    private UIController UIController;

    void Start() {
        UIController = GetComponent<UIController>();
    }

    void Update() {
        if (UIController.IsQuickMenuActive()) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                print("SKILLZ");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                print("PAUSE");
            }
            if (Input.GetKeyDown(KeyCode.Alpha3)) {
                print("QUIT");
            }
        }

    }
}
