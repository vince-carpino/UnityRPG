using UnityEngine;

public class Gun : MonoBehaviour {
    [SerializeField]
    [Range(0.5f, 1.5f)]
    private float fireRate = 1;

    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    private float timer;

    void Update() {
        timer += Time.deltaTime;

        if (timer >= fireRate) {
            if (Input.GetButton("Fire1")) {
                timer = 0;
                Fire();
            }
        }
    }

    private void Fire() {
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100f)) {
            var health = hitInfo.collider.gameObject.GetComponent<Health>();

            if (health != null) {
                health.TakeDamage(damage);
            }
        }
    }
}
