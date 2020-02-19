using UnityEngine;

public class GrenadeLauncherOld : MonoBehaviour {
    private bool _CanFire = true;
    private float _Timer;
    private Rigidbody _RB;
    private UIController _UI;

    public GameObject grenadePrefab;
    public float LaunchSpeed;
    public float CooldownTime = 3f;
    public float AimSpeed = 1f;
    public Transform FirePoint;
    public float MinMaxAimDegrees = 45f;

    void Start() {
        _Timer = CooldownTime;
        _RB = gameObject.transform.parent.GetComponent<Rigidbody>();
        _UI = GameManager.UIController;
        FirePoint = transform;

        string text = GetRechargeValueAsString();
        _UI.SetWeaponCooldownText(text);
    }

    void FixedUpdate() {
        if (_CanFire) {
            return;
        }

        Recharge();
    }

    string GetRechargeValueAsString() {
        return Mathf.Ceil((_Timer / CooldownTime) * 100).ToString();
    }

    void Recharge() {
        _Timer += Time.deltaTime;

        if (_Timer >= CooldownTime) {
            _Timer = CooldownTime;
            _CanFire = true;
        }

        string text = GetRechargeValueAsString();
        _UI.SetWeaponCooldownText(text);
    }

    public void Fire() {
        _CanFire = false;
        _Timer = 0f;
        GameObject newProjectile = Instantiate(grenadePrefab, FirePoint.position, FirePoint.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * LaunchSpeed + _RB.velocity, ForceMode.Impulse);
    }

    public bool CanFire() {
        return _CanFire;
    }
}
