using UnityEngine;

public class Weapon : MonoBehaviour {
    private bool _CanFire = true;
    private float _Timer;
    private Rigidbody _RB;
    private UIController _UI;

    public GameObject ProjectilePrefab;
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

        string text = RechargeMath().ToString();
        _UI.SetWeaponCooldownText(text);
    }

    void FixedUpdate() {
        RechargeLogic();
    }

    float RechargeMath() {
        return Mathf.Ceil((_Timer / CooldownTime) * 100);
    }

    void RechargeLogic() {
        if (_CanFire) {
            return;
        }

        _Timer += Time.deltaTime;

        if (_Timer >= CooldownTime) {
            _Timer = CooldownTime;
            _CanFire = true;
        }

        string text = RechargeMath().ToString();
        _UI.SetWeaponCooldownText(text);
    }

    public void Fire() {
        _CanFire = false;
        _Timer = 0f;
        GameObject newProjectile = Instantiate(ProjectilePrefab, FirePoint.position, FirePoint.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * LaunchSpeed + _RB.velocity, ForceMode.Impulse);
    }

    public bool CanFire() {
        return _CanFire;
    }
}
