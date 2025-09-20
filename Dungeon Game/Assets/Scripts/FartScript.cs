using UnityEngine;

public class FartScript : MonoBehaviour, IWeapon
{
    public float dashSpeed;
    public AmmoScript ammo;

    public void Use()
    {
        if (Input.GetKeyDown(KeyCode.L) && ammo.canUseWeapon)
        {
            Dash();
            Debug.Log("dog");
        }
    }

    public void Dash()
    {
        Rigidbody2D rb = PlayerHand.instance.gameObject.GetComponent<Rigidbody2D>();
        TopDownMoveScript move = PlayerHand.instance.gameObject.GetComponent<TopDownMoveScript>();

        Vector3 dashVector = new Vector3(dashSpeed * move.moveX, dashSpeed * move.moveY, 0);

        rb.AddForce(dashVector, ForceMode2D.Impulse);

        ammo.UseAmmo(1);
    }
}
