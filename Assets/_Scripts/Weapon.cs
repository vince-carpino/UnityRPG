using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour {
    private bool _CanFire = true;
    private float _Timer;
    private Rigidbody _RB;
    private GameManager _GM;
    private UIController _UI;

    public GameObject ProjectilePrefab;
    public float LaunchSpeed;
    public float CooldownTime = 3f;
    public Transform FirePoint;

    void Start() {
        _Timer = CooldownTime;
        _RB = gameObject.transform.parent.GetComponent<Rigidbody>();
        _GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _UI = GameObject.FindGameObjectWithTag("GameController").GetComponent<UIController>();
        FirePoint = transform;

        string text = ((_Timer / CooldownTime) * 100).ToString();
        _UI.SetWeaponCooldownText(text);
    }

    void FixedUpdate() {
        if (_CanFire) {
            return;
        }

        _Timer += Time.deltaTime;

        if (_Timer >= CooldownTime) { 
            _Timer = CooldownTime;
            _CanFire = true;
        }

        string text = Mathf.Ceil((_Timer / CooldownTime) * 100).ToString();
        _UI.SetWeaponCooldownText(text);
    }

    public void Fire() {
        _CanFire = false;
        _Timer = 0f;
        GameObject newProjectile = Instantiate(ProjectilePrefab, FirePoint.position, FirePoint.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * LaunchSpeed + _RB.velocity, ForceMode.Impulse);
        // StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown() {
        yield return new WaitForSeconds(CooldownTime);
        _CanFire = true;
    }

    public bool CanFire() {
        return _CanFire;
    }
}
