using UnityEngine;

public class BulletScript : MonoBehaviour, IDamager
{
    public Rigidbody2D rb;
    public IEnemy enemy;
    public float damage;

    public void SetupBullet(float speed, float timeAlive, Vector2 direction)
    {
        rb.linearVelocity = direction * speed;
        Invoke("KillBullet", timeAlive);
    }

    public void KillBullet()
    {
        Destroy(gameObject);
    }

    public void Hit(GameObject obj)
    {
        obj.GetComponent<HealthScript>().TakeDamage(damage);
        KillBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy = collision.gameObject.GetComponent<IEnemy>();
        if (enemy != null)
        {
            Hit(collision.gameObject);
        }
    }
}
