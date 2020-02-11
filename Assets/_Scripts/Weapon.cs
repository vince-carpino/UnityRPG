using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour {
    private Vector3 LaunchVector;
    private bool _CanFire = true;

    public GameObject ProjectilePrefab;
    public float ProjectileSpeed;
    public float CooldownTime = 3f;
    public Transform FirePoint;

    void Start() {
        FirePoint = transform;
    }

    public void Fire() {
        _CanFire = false;
        GameObject newProjectile = Instantiate(ProjectilePrefab, FirePoint.position, FirePoint.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * ProjectileSpeed, ForceMode.Impulse);
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
