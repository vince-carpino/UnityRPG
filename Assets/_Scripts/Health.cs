using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField]
    private int startingHealth = 5;

    private int currentHealth;

    void OnEnable() {
        currentHealth = startingHealth;
    }

    void Update() {

    }

    public void TakeDamage(int damageAmount) {
        currentHealth -= damageAmount;

        if (currentHealth <= 0) {
            Die();
        }
    }

    private void Die() {
        gameObject.SetActive(false);
    }
}
