using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour {
    private Vector3 LaunchVector;
    private bool _CanFire = true;

    public GameObject ProjectilePrefab;
    public float LaunchSpeed;
    public float CooldownTime = 3f;
    public Transform FirePoint;
    private Rigidbody RB;

    void Start() {
        FirePoint = transform;
        RB = gameObject.transform.parent.GetComponent<Rigidbody>();
    }

    public void Fire() {
        _CanFire = false;
        GameObject newProjectile = Instantiate(ProjectilePrefab, FirePoint.position, FirePoint.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * LaunchSpeed + RB.velocity, ForceMode.Impulse);
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
