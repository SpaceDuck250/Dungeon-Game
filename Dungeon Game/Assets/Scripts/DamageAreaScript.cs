using UnityEngine;

public class DamageAreaScript : MonoBehaviour
{
    public void Activate(float time)
    {
        gameObject.SetActive(true);
        Invoke("Deactivate", time);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) // Actually it should be mobs that detect this since it can hit several
    {
        Debug.Log("Hit " + collision.gameObject.name);
    }
}
