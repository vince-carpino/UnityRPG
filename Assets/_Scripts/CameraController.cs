using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private float sensitivity = 50;

    private CinemachineComposer composer;

    void Start() {
        composer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();
    }

    void Update() {
        float vertical = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        composer.m_TrackedObjectOffset.y += vertical;
        composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, -10f, 10f);
    }
}
