using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private float sensitivity = 50f;

    private CinemachineFreeLook freeLook;

    void Start() {
        freeLook = GetComponent<CinemachineFreeLook>();
    }

    void Update() {
        if (Input.GetButtonDown("Fire2")) {
            freeLook.m_Orbits[1].m_Radius /= 2f;
        }

        if (Input.GetButtonUp("Fire2")) {
            freeLook.m_Orbits[1].m_Radius *= 2f;
        }
    }
}
