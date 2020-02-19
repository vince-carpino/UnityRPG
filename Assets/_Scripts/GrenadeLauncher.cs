﻿using UnityEngine;

public class GrenadeLauncher : MonoBehaviour {
    private float _Timer;
    private Rigidbody _RB;
    private UIController _UI;

    public GameObject grenadePrefab;
    public float LaunchSpeed = 1f;
    public float CooldownTime = 3f;
    public Transform FirePoint;

    void Start() {
        _Timer = CooldownTime;
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

        Recharge();
    }

    string GetRechargeValueAsString() {
        return Mathf.Ceil((_Timer / CooldownTime) * 100).ToString();
    }

    void Recharge() {
        _Timer += Time.deltaTime;

        if (_Timer >= CooldownTime) {
            _Timer = CooldownTime;
        }

        string text = GetRechargeValueAsString();
        _UI.SetWeaponCooldownText(text);
    }

    public void Fire() {
        _Timer = 0f;
        GameObject newProjectile = Instantiate(grenadePrefab, FirePoint.position, FirePoint.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * LaunchSpeed + _RB.velocity, ForceMode.Impulse);
    }

    public bool CanFire() {
        return _Timer >= CooldownTime;
    }
}