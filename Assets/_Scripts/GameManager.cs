using UnityEngine;

public class GameManager : MonoBehaviour {
    private string GameControllerTag = "GameController";
    private string MainCameraTag = "MainCamera";

    public static string EnemyTag = "Enemy";
    public static string FireAxisName = "Fire1";
    public static GameObject MainCamera;
    public static UIController UIController;
    public static GameObject Player;

    void Awake() {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start() {
        MainCamera = GameObject.FindGameObjectWithTag(MainCameraTag).gameObject;
        UIController = GameObject.FindGameObjectWithTag(GameControllerTag).GetComponent<UIController>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            UIController.ToggleQuickMenu();
        }
    }
}
