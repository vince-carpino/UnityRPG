using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour {
    private Vector3 LaunchVector;
    private bool _CanFire = true;

    public Projectile Projectile;
    public float ProjectileSpeed;
    public float CooldownTime = 3f;
    public Transform FirePoint;

    void Start() {
        FirePoint = transform;
    }

    void Update() {
    }

    public void Fire() {
        _CanFire = false;
        var newProjectile = Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
        newProjectile.Rigidbody.AddForce(transform.forward * ProjectileSpeed);
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown() {
        yield return new WaitForSeconds(CooldownTime);
        _CanFire = true;
    }

    public bool CanFire() {
        return _CanFire;
    }
}
