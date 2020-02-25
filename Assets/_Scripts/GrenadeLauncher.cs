using UnityEngine;

public class GrenadeLauncher : MonoBehaviour {
    [SerializeField]
    private GameObject grenadePrefab = null;

    [SerializeField]
    private float launchSpeed = 1f;

    [SerializeField]
    private float cooldownTime = 3f;

    [SerializeField]
    private Transform firePoint = null;

    [SerializeField]
    private Transform cameraTransform = null;

    private float _Timer;
    private Rigidbody _RB;
    private UIController _UI;

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

    private void MatchCameraRotation() {
        firePoint.transform.forward = cameraTransform.forward;
    }

    private string GetRechargeValueAsString() {
        return Mathf.Ceil((_Timer / cooldownTime) * 100).ToString();
    }

    private void Recharge() {
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
        newProjectile.GetComponent<Rigidbody>().AddForce(firePoint.forward * launchSpeed + _RB.velocity, ForceMode.Impulse);
    }

    public bool CanFire() {
        return _Timer >= cooldownTime;
    }
}
