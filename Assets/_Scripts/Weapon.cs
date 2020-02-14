using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour {
    private bool _CanFire = true;
    private float _Timer;
    private GameManager GM;

    public GameObject ProjectilePrefab;
    public float LaunchSpeed;
    public float CooldownTime = 3f;
    public Transform FirePoint;
    private Rigidbody RB;

    void Start() {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        GM.TimerText.text = string.Format("{0:0.0} s", CooldownTime);
        FirePoint = transform;
        RB = gameObject.transform.parent.GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if (_CanFire) {
            return;
        }

        _Timer -= Time.deltaTime;

        if (_Timer <= 0f) { 
            _Timer = CooldownTime;
        }

        GM.TimerText.text = string.Format("{0:0.0} s", _Timer);
    }

    public void Fire() {
        _CanFire = false;
        _Timer = CooldownTime;
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
