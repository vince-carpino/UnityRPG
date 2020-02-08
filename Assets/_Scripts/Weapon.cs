using UnityEngine;

public class Weapon : MonoBehaviour {
    private Vector3 LaunchVector;

    public Projectile Projectile;
    public float ProjectileSpeed;
    public float Cooldown;
    public Transform FirePoint;
    public float LaunchAngle;

    void Start() {
        FirePoint = transform;
    }

    void Update() {
    }

    public void Fire() {
        var newProjectile = Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
        newProjectile.Rigidbody.AddForce(transform.forward * ProjectileSpeed);
    }
}
