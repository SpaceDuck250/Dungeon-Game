using UnityEngine;

public class HealthScript : MonoBehaviour // in future we can ref IEnemy to get custom unique effects or just use events
{
    public float health;
    public float maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
