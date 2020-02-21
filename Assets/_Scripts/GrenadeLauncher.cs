using UnityEngine;

public class GrenadeLauncher : MonoBehaviour {
    private float _Timer;
    private Rigidbody _RB;
    private UIController _UI;

    [SerializeField]
    private float sensitivity = 50f;

    [SerializeField]
    private GameObject grenadePrefab;

    [SerializeField]
    private float launchSpeed = 1f;

    [SerializeField]
    private float cooldownTime = 3f;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private Transform cameraTransform;

    void Start() {
        _Timer = cooldownTime;
        _RB = GetComponent<Rigidbody>();
        _UI = GameManager.UIController;

        string text = GetRechargeValueAsString();
        _UI.SetWeaponCooldownText(text);
    }

    void FixedUpdate() {
        if (CanFire() && Input.GetButton("Fire1")) {
            Fire();
            return;
        }

        MatchCameraRotation();

        Recharge();
    }

    void MatchCameraRotation() {
        firePoint.transform.forward = cameraTransform.forward;
    }

    string GetRechargeValueAsString() {
        return Mathf.Ceil((_Timer / cooldownTime) * 100).ToString();
    }

    void Recharge() {
        _Timer += Time.deltaTime;

        if (_Timer >= cooldownTime) {
            _Timer = cooldownTime;
        }

        string text = GetRechargeValueAsString();
        _UI.SetWeaponCooldownText(text);
    }

    public void Fire() {
        _Timer = 0f;
        GameObject newProjectile = Instantiate(grenadePrefab, firePoint.position, firePoint.rotation);
        newProjectile.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * launchSpeed + _RB.velocity, ForceMode.Impulse);
    }

    public bool CanFire() {
        return _Timer >= cooldownTime;
    }
}
